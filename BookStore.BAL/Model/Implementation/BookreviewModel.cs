using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStore.BAL.RequestClasses;
using BookStore.BAL.Utility;
using BookStore.DAL;
using BookStore.DAL.Implementation;
using BookStore.DAL.Interface;
using BookStore.DAL.Repository;

namespace BookStore.BAL.Model.Implementation
{
    public class BookreviewModel
    {
        private readonly IBookreviewRepository repoBookreview;
        private readonly IUsersRepository repoUsers;
        private readonly IUnitOfWork unitOfWork;
        private readonly IDbFactory idbfactory;
        SaveLogUtility sLogUtility = new SaveLogUtility();
        public BookreviewModel()
        {
            idbfactory = new DbFactory();
            unitOfWork = new UnitOfWork(idbfactory);
            repoBookreview = new BookreviewRepository(idbfactory);
            repoUsers = new UsersRepository(idbfactory);
        }
        public string GetCreatBy(int id)
        {
            try
            {
                var cod = repoBookreview.GetNonAsync(c => c.id == id).userid;
                var userSurname = repoUsers.GetNonAsync(u => u.id == cod).surname;
                var userFirstname = repoUsers.GetNonAsync(u => u.id == cod).firstname;
                string user = userSurname + ' ' + userFirstname;

                return user;
            }
            catch (Exception ex)
            {

            }
            return null;
        }
        public string GetDateCreate(int id)
        {
            try
            {
                var p = repoBookreview.GetNonAsync(f => f.id == id).reviewdate;
                var pdate = DateTime.Parse(p.ToString()).ToString("dd-MM-yyyy hh:mm:ss");
                //var pdate = p.ToString("dd-MM-yyyy hh:mm:ss");

                return pdate;
            }
            catch (Exception ex)
            {

            }
            return null;
        }
        public async Task<BookreviewRequestClass> ViewReviewDetails(int id)
        {
            var returnVal = new BookreviewRequestClass();
            try
            {
                var y = await repoBookreview.Get(p => p.id == id);



                returnVal.id = y.id;
                returnVal.bookid = (int)y.bookid;
                returnVal.userid = (int)y.userid;
                returnVal.reviewedby = GetCreatBy(y.id);
                returnVal.userreview = y.userreview;
                returnVal.reviewdate = (DateTime)y.reviewdate;

                return returnVal;
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            return null;
        }
        public async Task<BookreviewRequestClass> GetListOfReviews(int id)
        {
            var returnProp = new BookreviewRequestClass();
            try
            {
                var bookReviewList = await repoBookreview.GetMany(a => a.id == id);
                returnProp.BookreviewList = bookReviewList;
                return returnProp;
            }
            catch (Exception ex)
            {

                returnProp.ErrorCode = -2;
                returnProp.ErrorText = "Internal Error Occurred Kindly Contact Administrator";
                StringBuilder sb = new StringBuilder();
                sb.AppendFormat("ErrorCode: {0} - ErrorText {1} - SysteError", returnProp.ErrorCode, ex.Message);
                sLogUtility.SaveLog(sb.ToString());
                return returnProp;
            }
        }
        public async Task<BookreviewRequestClass> AddBookReview(Bookreview p)
        {
            var returnVal = new BookreviewRequestClass();
            var review = await repoBookreview.Get(l => l.userid == p.userid);
            if (review != null)
            {
                returnVal.ErrorCode = -2;
                returnVal.ErrorText = "You already Reviewed This Book!!";

                return returnVal;
            }

            p.reviewdate = DateTime.Now;
            p.userid = p.userid;
            repoBookreview.Add(p);
            try
            {
                var retV = await unitOfWork.Commit(Convert.ToUInt16(p.userid)) > 0 ? true : false;

                if (retV)
                {
                    returnVal.ErrorCode = 0;
                    returnVal.ErrorText = "Record Added Succesfully";
                    return returnVal;
                }
            }
            catch (Exception ex)
            {
                sLogUtility.SaveLog(ex.Message == null ? ex.InnerException.Message : ex.Message);
                returnVal.ErrorCode = -1;
                returnVal.ErrorText = ex.Message == null ? ex.InnerException.Message : ex.Message;

                return returnVal;
            }

            return returnVal;
        }
        public async Task<BookreviewRequestClass> EditReview(Bookreview p)
        {
            var returnVal = new BookreviewRequestClass();

            var y = await repoBookreview.Get(a => a.id == p.id);

            if (y != null)
            {
                if (
                y.surname == p.surname &&
                y.othernames == p.othernames &&
                y.nationality == p.nationality &&
                y.address == p.address &&
                y.email == p.email &&
                y.title == p.title &&
                y.datecreated == p.datecreated

                    )
                {
                    returnVal.ErrorCode = -1;
                    returnVal.ErrorText = "No change is made";
                }
                else
                {

                    y.surname = p.surname;
                    y.othernames = p.othernames;
                    y.nationality = p.nationality;
                    y.address = p.address;
                    y.email = p.email;
                    y.title = p.title;
                    y.datecreated = p.datecreated;



                    repoAuthors.Update(y);
                    try
                    {
                        var retV = await unitOfWork.Commit(Convert.ToInt16(p.userid)) > 0 ? true : false;

                        if (retV)
                        {
                            returnVal.ErrorCode = 0;
                            returnVal.ErrorText = "Record Updated Succesfully";

                            return returnVal;
                        }
                    }
                    catch (Exception ex)
                    {
                        returnVal.ErrorCode = -1;
                        returnVal.ErrorText = ex.Message == null ? ex.InnerException.Message : ex.Message;
                        sLogUtility.SaveLog(ex.Message == null ? ex.InnerException.Message : ex.Message);

                        return returnVal;
                    }
                }
            }

            return returnVal;
        }
    }
}
