using Core.Helpers.ProducerHelper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnluCo.DAL.Abstract;
using UnluCo.Entities.Concrete;
using UnluCo.Entities.Models;

namespace UnluCo.DAL.Concrete.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<User, UnluCoContext>, IUserDal
    {
        public void AddWithHash(User user)
        {

            using (UnluCoContext context = new UnluCoContext())
            {
                var crypto = new SimpleCrypto.PBKDF2();
                var encrypedPassword = crypto.Compute(user.Password);
                user.Password = encrypedPassword;
                user.PasswordSalt = crypto.Salt;

                var entity = context.Entry(user);
                entity.State = EntityState.Added;
                context.SaveChanges();
                // send mail
                EmailProducer.SendMail(user);
            }
        }

        private int _rejectCount = 0;
        public object Login(LoginModel user)
        {
            using (UnluCoContext context = new UnluCoContext())
            {
                var crypto = new SimpleCrypto.PBKDF2();
                var _user = context.Users.FirstOrDefault(x => x.Email.Equals(user.Email));
                if (!(_user is null) && _user.isActive.Equals(true))
                {
                    if (_user.Email.Equals(user.Email) && _user.Password.Equals(crypto.Compute(user.Password, _user.PasswordSalt)))
                    {
                        _rejectCount = 0;
                        return _user;
                    }
                    else
                    {
                        _rejectCount++;
                    }

                    if (_rejectCount==3)
                    {
                        _rejectCount = 0;
                        _user.isActive = false;
                        var entity = context.Entry(_user);
                        entity.State = EntityState.Modified;
                        context.SaveChanges();
                        // send mail
                        EmailProducer.SendMail(_user);

                        return false;
                    }
                }

                return null;
            }
        }
    }
}
