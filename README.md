# .Net Core 3.1 Enterprise Application Architecture
This is a complete architecture to support enterprise application.
Following things are implemented in this architecture.
- NLog
- Store Procedure
- Linq Query
- JWT
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



