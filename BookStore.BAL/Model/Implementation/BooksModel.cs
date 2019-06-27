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
    public class BooksModel
    {
        private readonly IAuthorsRepository repoAuthors;
        private readonly IUsersRepository repoUsers;
        private readonly IUnitOfWork unitOfWork;
        private readonly IDbFactory idbfactory;
        SaveLogUtility sLogUtility = new SaveLogUtility();
        public AuthorsModel()
        {
            idbfactory = new DbFactory();
            unitOfWork = new UnitOfWork(idbfactory);
            repoAuthors = new AuthorsRepository(idbfactory);
            repoUsers = new UsersRepository(idbfactory);
        }
        public string GetCreatBy(int id)
        {
            try
            {
                var cod = repoAuthors.GetNonAsync(c => c.id == id).userid;
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
                var p = repoAuthors.GetNonAsync(f => f.id == id).datecreated;
                var pdate = DateTime.Parse(p.ToString()).ToString("dd-MM-yyyy hh:mm:ss");
                //var pdate = p.ToString("dd-MM-yyyy hh:mm:ss");

                return pdate;
            }
            catch (Exception ex)
            {

            }
            return null;
        }
        public async Task<AuthorsRequestClass> ViewAuthorsDetails(int id)
        {
            var returnVal = new AuthorsRequestClass();
            try
            {
                var y = await repoAuthors.Get(p => p.id == id);



                returnVal.id = y.id;
                returnVal.surname = y.surname;
                returnVal.othernames = y.othernames;
                returnVal.nationality = y.nationality;
                returnVal.address = y.address;
                returnVal.email = y.email;
                returnVal.title = y.title;
                returnVal.datecreated = (DateTime)y.datecreated;

                return returnVal;
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            return null;
        }
        public Authors GetAuthorBySurname(string surname)
        {
            var author = repoAuthors.GetNonAsync(P => P.surname == surname);
            return author;

        }
        public async Task<AuthorsRequestClass> GetListOfAuthors()
        {
            var returnProp = new AuthorsRequestClass();
            try
            {
                var authorsList = await repoAuthors.GetAll();
                returnProp.AuthorsList = authorsList;
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
        public async Task<AuthorsRequestClass> AddAuthor(Authors p)
        {
            var returnVal = new AuthorsRequestClass();
            var actType = await repoAuthors.Get(l => l.surname == p.surname);
            if (actType != null)
            {
                returnVal.ErrorCode = -2;
                returnVal.ErrorText = "Author already Exists!!";

                return returnVal;
            }

            p.datecreated = DateTime.Now;
            p.userid = p.userid;
            repoAuthors.Add(p);
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
        public async Task<AuthorsRequestClass> EditAuthor(Authors p)
        {
            var returnVal = new AuthorsRequestClass();

            var y = await repoAuthors.Get(a => a.id == p.id);

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
