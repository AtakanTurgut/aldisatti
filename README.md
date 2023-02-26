# Shopping website application (AldiSatti) with ASP.NET MVC5

## AldiSatti Api Addresses

If we want to start the project with [Microsoft Visual Studio](https://visualstudio.microsoft.com/), we start the project by right-clicking on the "[\Views\Home\Index.cshtml](https://github.com/AtakanTurgut/aldisatti/blob/main/aldiSatti/Views/Home/Index.cshtml)" file while the project is open and selecting "View in Browser ([Selected Browser](https://www.google.com.tr/))".

If we want, we can also use `\Index.cshtml` of other "[\Views](https://github.com/AtakanTurgut/aldisatti/blob/main/aldiSatti/Views/Home/Index.cshtml)" files to see how other pages look.

However, it's best to start the project with "[\Views\Home\Index.cshtml](https://github.com/AtakanTurgut/aldisatti/blob/main/aldiSatti/Views/Home/Index.cshtml)" to run it properly.

Ready-made [themes](https://www.free-css.com/free-css-templates) were processed and made suitable for the project.

In order to confirm the cart, the user must first log in. <br />
The application also has an admin panel. <br />
Only people registered as administrators can login to the admin page. <br />
Admin can perform general operations through the panel. <br />
<ul>
  <li>The website is accessible.</li>
  <li>Admin can see what's happening on the dashboard from the control panel.</li>
  <li>Admin can perform operations related to Categories and list all Categories. Can add, delete, edit Categories.</li>
  <li>Admin can perform operations related to Products and list all Products. Can add, delete, edit Products.</li>
  <li>Admin can list all Orders and examine it in detail. Can change order statuses.</li>
  <li>Admin can receive order statuses as notification.</li>
</ul>  

Use this user name and password for the admin page.

                UserName : atakanturgut
                Password : 123456

Use this user name and password for the user page.

                UserName : samilyildirim
                Password : 123456

The project runs on "[localhost:?/](https://localhost:44374/)".

## Used Packages

- Some packages can be installed from the "[NuGet Gallery](https://www.nuget.org/packages/Microsoft.AspNet.Identity.Core)" with the help of the `Tools > NuGet Package Manager > Package Manager Console`.

- [EntityFramework 6.4.4](https://www.nuget.org/packages/EntityFramework/)
```
    PM>  NuGet\Install-Package EntityFramework -Version 6.4.4
```
- [Microsoft.AspNet.Identity.Core 2.2.3](https://www.nuget.org/packages/Microsoft.AspNet.Identity.Core)
```
    PM>  NuGet\Install-Package Microsoft.AspNet.Identity.Core -Version 2.2.3
```
- [Microsoft.AspNet.Identity.Owin 2.2.3](https://www.nuget.org/packages/Microsoft.AspNet.Identity.Owin/)
```
    PM>  NuGet\Install-Package Microsoft.AspNet.Identity.Owin -Version 2.2.3
```
- [Microsoft.AspNet.Identity.EntityFramework 2.2.3](https://www.nuget.org/packages/Microsoft.AspNet.Identity.EntityFramework/)
```
    PM>  NuGet\Install-Package Microsoft.AspNet.Identity.EntityFramework -Version 2.2.3
```
- [Microsoft.Owin.Host.SystemWeb 4.2.2](https://www.nuget.org/packages/Microsoft.Owin.Host.SystemWeb)
```
    PM>  NuGet\Install-Package Microsoft.Owin.Host.SystemWeb -Version 4.2.2
```

- [ ] Use this script to see the page in Turkish [[source]](https://datatables.net/examples/advanced_init/language_file.html):
```html
    <script type="text/javascript">
        $(function () {
            $("#example1").dataTable({
                "language": {
                    "url": "//cdn.datatables.net/plug-ins/9dcbecd42ad/i18n/Turkish.json"
                }
            });
            $('#example2').dataTable({
                "bPaginate": true,
                "bLengthChange": false,
                "bFilter": false,
                "bSort": true,
                "bInfo": true,
                "bAutoWidth": false
            });
        });
    </script>

```

----
## AldiSatti Project [Images](https://github.com/AtakanTurgut/aldisatti/tree/main/pictures)

### 1. Home Page:  https://localhost:44374/Home/Index
![](/pictures/HomePage1.PNG) 
![](/pictures/HomePage2.PNG)

### 2. Product Details Page:  https://localhost:44374/Home/ProductDetails/1
![](/pictures/ProductDetailsPage.PNG)

### 3. Register Page:  https://localhost:44374/Account/Register
![](/pictures/RegisterPage.PNG)

### 4. Login Page:  https://localhost:44374/Account/Login
![](/pictures/LoginPage.PNG)

### 5. User Profile Page:  https://localhost:44374/Account/UserProfile
![](/pictures/UserProfilePage.PNG)

### 6. Cart Page:  https://localhost:44374/Cart/Index
![](/pictures/CartPage.PNG)

### 7. Cart Checkout Page:  https://localhost:44374/Cart/Checkout
![](/pictures/CheckoutPage.PNG)

### 8. Order History Page:  https://localhost:44374/Account/Index
![](/pictures/AccountPage.PNG)

### 9. Order Details Page:  https://localhost:44374/Account/Details/2
![](/pictures/AccountDetailsPage.PNG)

### 10. Admin Page:  https://localhost:44374/Admin/Index
![](/pictures/AdminPage.PNG)
![](/pictures/AdminPageCorner.PNG)

### 11. Product List Page:  https://localhost:44374/Product/Index
![](/pictures/ProductPage.PNG)

### 12. Product Create Page:  https://localhost:44374/Product/Create
![](/pictures/ProductCreatePage.PNG)

### 13. Category Page:  https://localhost:44374/Category/Index
![](/pictures/CategoryPage.PNG)

### 14. Order List Page:  https://localhost:44374/Order/Index
![](/pictures/OrderPage.PNG)

### 15. Order Details Page:  https://localhost:44374/Order/Details/1
![](/pictures/OrderDetailsPage.PNG)
