# .Net Core 3.1 Web API Enterprise Application Architecture
This is a complete architecture to support enterprise application.
Following things are implemented in this architecture.
- NLog
- Store Procedure
- Linq Query
- JWT
- SignalR
- Swagger
- Generic Repository
- Generic Store Procedure Call
- Unit of work

------------
# Swagger Example:


[![Swagger API](https://raw.githubusercontent.com/siddiquefaisal10/.Net-Core-3.1-Enterprise-Application-Architecture/master/Image/Capture.PNG "Swagger API")](https://raw.githubusercontent.com/siddiquefaisal10/.Net-Core-3.1-Enterprise-Application-Architecture/master/Image/Capture.PNG "Swagger API")

### Swagger API Explaination:
- Login:
This method returns a JWT token.
Role authentication can also be done just need to change
> [Authorize] to [Authorize(Role="RoleId Entered in JWT")]
in controller.

-  DecodeToken:
This method decode token, use to identity user and it provide security to application.Eample: Roleid is encoded in tokens so if hacker changes the token he/she will be unauthorized.
> If user need his family member name so he is only sending a GET request and token.We will decode token at run time and use his Roldid(Encoded in JWT token) to idetitfy user

- DataFromLinqQuery:
Returns data using linq query and entity Framework.

- DataFromSP:
Returns data using Store Procedure and Enitity Framework.



------------

### # **HOW TO WORK IN PROJECT:**
1. Add Controller
2. Add Service and Interface in Services project.
> Don't  forget to register service in servicemodule.cs
`Example: services.AddTransient<ITestService, TestService>();`

3. Add Unit of work into service file using dependency injection.
` private readonly IUnitOfWork _unitOfWork;
        private readonly AppSettings _appSettings;

        public TestService(IUnitOfWork unitOfWork, IOptions<AppSettings> appSettings)
        {
            _unitOfWork = unitOfWork;
            _appSettings = appSettings.Value;
        }`

4. User unit of work to use Linq or Store Procedure.
###### Linq:
` public TestTable DbLinq()
        {
            var userRepository = _unitOfWork.GetRepository<TestTable>();
            int a = 2;
            var user = userRepository.GetAll().Where(c => c.ID == a).SingleOrDefault();
            if (user == null)
                return null;
            return user;
        }`
###### Store Procedure
` public TestTable SpQuery()
        {
            var id = new SqlParameter("@UserId", SqlDbType.Int) { Value = 2 };
            return _unitOfWork.SpRepository<TestTable>("testSP @UserId", id).SingleOrDefault();
        }`
        
5. Make Models in TwinCityCoders.Models project and add dbset in DatabaseContext.cs file.
` public DbSet<TestTable> TestTables { get; set; }`

Thats it !!



