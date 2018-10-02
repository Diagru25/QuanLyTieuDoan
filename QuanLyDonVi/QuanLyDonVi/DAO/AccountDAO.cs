using QuanLyDonVi.Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyDonVi.DAO
{
    public class AccountDAO
    {
        QuanLyTieuDoanDbContext db = null;

        public AccountDAO()
        {
            db = new QuanLyTieuDoanDbContext();
        }



        public bool Is_login(string username, string pass)
        {
            if (db.Accounts.Where(x => x.Username == username && x.Password == pass).SingleOrDefault() != null)
            {
                return true;
            }
            else
                return false;
        }

        public List<Account> GetAll()
        {
            return db.Accounts.ToList();
        }

        public bool Add(Account item)
        {
            try
            {
                db.Accounts.Add(item);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Edit(string username, string pass)
        {
            try
            {
                Account temp = db.Accounts.Where(x => x.Username == username).SingleOrDefault();
                temp.Password = pass;
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Remove(string username)
        {
            try
            {
                db.Accounts.Remove(db.Accounts.Where(x => x.Username == username).SingleOrDefault());
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
