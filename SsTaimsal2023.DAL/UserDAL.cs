using Microsoft.EntityFrameworkCore;
using SsTaimsal2023.EL;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;


namespace SsTaimsal2023.DAL
{
    public class UserDAL
    {
        private static async void EncriptarMD5(UserDev userDev) { 
            using (var md5 = MD5.Create()) {
                var result = md5.ComputeHash(Encoding.ASCII.GetBytes(userDev.Password));
                var strEncript = "";
                for (int i = 0; i < result.Length; i++)
                    strEncript += result[i].ToString("x2").ToLower();
                userDev.Password = strEncript;
            }
        }

        private static async Task<bool> ExitsLogin(UserDev userDev, SystemTaimsalDevsContext systemTaimsalDevsContext) {
            bool result = false;
            var existUserLogin = await systemTaimsalDevsContext.UserDevs.FirstOrDefaultAsync(s => s.Login == userDev.Login && s.IdUser == userDev.IdUser);
            if (existUserLogin != null && existUserLogin.IdUser > 0 && existUserLogin.Login == userDev.Login)
                result = true;
            return result;
        }

        //------------------------------------------CRUD
        
        //CreateAsync
        public static async Task<int> AddAsync(UserDev pUserDev)
        {
            int result = 0;
            using (var dbContext = new SystemTaimsalDevsContext()) { 
                bool Loginexits =  await ExitsLogin(pUserDev, dbContext);
                if (Loginexits == false)
                {
                    pUserDev.RegistrationUser = DateTime.Now;
                    EncriptarMD5(pUserDev);
                    dbContext.Add(pUserDev);
                    result = await dbContext.SaveChangesAsync();
                }
                else
                    throw new Exception("Usuario existente");
            }
                return result;
        }

        //ModifyAsync
        public static async Task<int> ModifyAsync(UserDev pUserDev)
        {
            int result = 0;
            using (var dbc = new SystemTaimsalDevsContext()) {
                bool loginExist = await ExitsLogin(pUserDev, dbc);
                if (loginExist == false)
                {
                    var userDevs = await dbc.UserDevs.FirstOrDefaultAsync(s => s.IdUser == pUserDev.IdUser);
                    //Revisar si es Rol o User
                    //userDevs.IdUser = userDev.IdUser;
                    userDevs.IdRol = pUserDev.IdRol;
                    userDevs.NameUser = pUserDev.NameUser;
                    userDevs.StatusUser = pUserDev.StatusUser;
                    dbc.Add(userDevs);
                    result = await dbc.SaveChangesAsync();
                }
                else
                    throw new Exception("Usuario existente");
            }
            return result;
        }
        public static async Task<UserDev> GetByIdAsync(UserDev pUsuario)
        {
            var usuario = new UserDev();
            using (var bdContexto = new SystemTaimsalDevsContext())
            {
                usuario = await bdContexto.UserDevs.FirstOrDefaultAsync(s => s.IdUser == pUsuario.IdUser);
            }
            return usuario;
        }
        public static async Task<List<UserDev>> GetAllAsync()
        {
            var usuarios = new List<UserDev>();
            using (var bdContexto = new SystemTaimsalDevsContext())
            {
                usuarios = await bdContexto.UserDevs.ToListAsync();
            }
            return usuarios;
        }

        internal static IQueryable<UserDev> QuerySelect(IQueryable<UserDev> pQuery, UserDev pUserdev) 
        {
            if (pUserdev.IdUser > 0)
                pQuery = pQuery.Where(s => s.IdUser == pUserdev.IdUser);
            if (pUserdev.IdRol > 0)
                pQuery = pQuery.Where(s => s.IdRol == pUserdev.IdRol);
            if (!string.IsNullOrWhiteSpace(pUserdev.NameUser))
                pQuery = pQuery.Where(s => s.NameUser.Contains(pUserdev.NameUser));
            if (!string.IsNullOrWhiteSpace(pUserdev.Login))
                pQuery = pQuery.Where(s => s.Login.Contains(pUserdev.Login));
            if (pUserdev.StatusUser > 0)
                pQuery = pQuery.Where(s => s.StatusUser == pUserdev.StatusUser);
            if(pUserdev.RegistrationUser.Year > 1000)
            {
                DateTime InitialDate = new DateTime(pUserdev.RegistrationUser.Year, pUserdev.RegistrationUser.Month, pUserdev.RegistrationUser.Day, 0, 0, 0);
                DateTime FinalDate = InitialDate.AddDays(1).AddMilliseconds(-1);
                pQuery = pQuery.Where(s => s.RegistrationUser >= InitialDate && s.RegistrationUser <= FinalDate);
            }
            pQuery = pQuery.OrderByDescending(s=> s.IdUser).AsQueryable();
            return pQuery;

        }

    }

}
