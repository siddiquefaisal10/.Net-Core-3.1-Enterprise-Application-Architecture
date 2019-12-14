using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;
using TwinCityCoders.DBCore.Uow;
using TwinCityCoders.Models.Entities.TestTableEntity;
using TwinCityCoders.Utilities.Hashing;

namespace TwinCityCoders.Services.Test
{
    public class TestService: ITestService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly AppSettings _appSettings;

        public TestService(IUnitOfWork unitOfWork, IOptions<AppSettings> appSettings)
        {
            _unitOfWork = unitOfWork;
            _appSettings = appSettings.Value;

        }


        public string Login()
        {
            string token = JWTToken.GenerateToken("140703", "140", "FaisalSiddique", "703", _appSettings.Secret);
            return "Bearer " + token;
        }        
        
        
        public TestTable DbLinq()
        {
            var userRepository = _unitOfWork.GetRepository<TestTable>();
            int a = 2;
            var user = userRepository.GetAll().Where(c => c.ID == a).SingleOrDefault();
            if (user == null)
                return null;

            return user;
        }


        public TestTable SpQuery()
        {
            var id = new SqlParameter("@UserId", SqlDbType.Int) { Value = 2 };
            return _unitOfWork.SpRepository<TestTable>("testSP @UserId", id).SingleOrDefault();

        }

    }
}
