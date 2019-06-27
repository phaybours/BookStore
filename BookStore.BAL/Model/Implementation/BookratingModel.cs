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
    public class BookratingModel
    {
        private readonly IBookratingRepository repoBookrating;
        private readonly IUsersRepository repoUsers;
        private readonly IUnitOfWork unitOfWork;
        private readonly IDbFactory idbfactory;
        SaveLogUtility sLogUtility = new SaveLogUtility();
        public BookratingModel()
        {
            idbfactory = new DbFactory();
            unitOfWork = new UnitOfWork(idbfactory);
            repoBookrating = new BookratingRepository(idbfactory);
            repoUsers = new UsersRepository(idbfactory);
        }
        public string GetCreatBy(int id)
        {
            try
            {
                var cod = repoBookrating.GetNonAsync(c => c.id == id).userid;
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
        public string GetDateRated(int id)
        {
            try
            {
                var p = repoBookrating.GetNonAsync(f => f.id == id).daterated;
                var pdate = DateTime.Parse(p.ToString()).ToString("dd-MM-yyyy hh:mm:ss");
                //var pdate = p.ToString("dd-MM-yyyy hh:mm:ss");

                return pdate;
            }
            catch (Exception ex)
            {

            }
            return null;
        }
        public async Task<BookratingRequestClass> ViewRatingDetails(int id)
        {
            var returnVal = new BookratingRequestClass();
            try
            {
                var y = await repoBookrating.Get(p => p.id == id);



                returnVal.id = y.id;
                returnVal.bookid = (int)y.bookid;
                returnVal.rating = (int)y.rating;
                returnVal.daterated = (DateTime)y.daterated;
                returnVal.userid = (int)y.userid;

                return returnVal;
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            return null;
        }
        public Bookrating GetRatingByBookId(int bookId)
        {
            var rating = repoBookrating.GetNonAsync(P => P.bookid == bookId);
            return rating;

        }
        public async Task<BookratingRequestClass> GetListOfBookRating()
        {
            var returnProp = new BookratingRequestClass();
            try
            {
                var bookratingList = await repoBookrating.GetAll();
                returnProp.BookratingList = bookratingList;
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
        public async Task<BookratingRequestClass> AddBookrating(Bookrating p)
        {
            var returnVal = new BookratingRequestClass();
            p.daterated = DateTime.Now;
            p.userid = p.userid;
            repoBookrating.Add(p);
            try
            {
                var retV = await unitOfWork.Commit(Convert.ToUInt16(p.userid)) > 0 ? true : false;

                if (retV)
                {
                    returnVal.ErrorCode = 0;
                    returnVal.ErrorText = "Book Rated Succesfully";
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
        public async Task<BookratingRequestClass> EditBookrating(Bookrating p)
        {
            var returnVal = new BookratingRequestClass();

            var y = await repoBookrating.Get(a => a.id == p.id);

            if (y != null)
            {
                if (
                y.bookid == p.bookid &&
                y.rating == p.rating &&
                y.daterated == p.daterated &&
                y.userid == p.userid

                    )
                {
                    returnVal.ErrorCode = -1;
                    returnVal.ErrorText = "No change is made";
                }
                else
                {

                    y.bookid = p.bookid;
                    y.rating = p.rating;
                    y.daterated = p.daterated;
                    y.userid = p.userid;



                    repoBookrating.Update(y);
                    try
                    {
                        var retV = await unitOfWork.Commit(Convert.ToInt16(p.userid)) > 0 ? true : false;

                        if (retV)
                        {
                            returnVal.ErrorCode = 0;
                            returnVal.ErrorText = "Rating Updated Succesfully";

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
