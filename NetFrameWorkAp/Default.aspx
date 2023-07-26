<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="NetFrameWorkAp._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <main>
        <section class="row" aria-labelledby="aspnetTitle">
            <h1 id="aspnetTitle">ASP.NET</h1>
            <p class="lead">ASP.NET is a free web framework for building great Web sites and Web applications using HTML, CSS, and JavaScript.</p>
            <p><a href="http://www.asp.net" class="btn btn-primary btn-md">Learn more &raquo;</a></p>
        </section>

        <div class="row">
            <section class="col-md-4" aria-labelledby="gettingStartedTitle">
                <h2 id="gettingStartedTitle">Getting started</h2>
                <p>
                    ASP.NET Web Forms lets you build dynamic websites using a familiar drag-and-drop, event-driven model.
                A design surface and hundreds of controls and components let you rapidly build sophisticated, powerful UI-driven sites with data access.
                </p>
                <p>
                    <a class="btn btn-default" href="https://go.microsoft.com/fwlink/?LinkId=301948">Learn more &raquo;</a>
                </p>
            </section>
            <section class="col-md-4" aria-labelledby="librariesTitle">
                <h2 id="librariesTitle">Get more libraries</h2>
                <p>
                    NuGet is a free Visual Studio extension that makes it easy to add, remove, and update libraries and tools in Visual Studio projects.
                </p>
                <p>
                    <a class="btn btn-default" href="https://go.microsoft.com/fwlink/?LinkId=301949">Learn more &raquo;</a>
                </p>
            </section>
            <section class="col-md-4" aria-labelledby="hostingTitle">
                <h2 id="hostingTitle">Web Hosting</h2>
                <p>
                    You can easily find a web hosting company that offers the right mix of features and price for your applications.
                </p>
                <p>
                    <a class="btn btn-default" href="https://go.microsoft.com/fwlink/?LinkId=301950">Learn more &raquo;</a>
                </p>
            </section>
        </div>
    <table>
            <tr>
                <td>Customer Name </td>
                <td>
                    <input type="text" name="txtCustomer" id="txtCustomer" /></td>
            </tr>
            <tr>
                <td>Customer Address </td>
                <td>
                    <input type="text" name="txtCustAddr" id="txtCustAddr" /></td>
            </tr>
            <tr>
                <td>
                    <input type="button" id="btnSave" value="Save to Local Storage" onclick="fnSaveData()" />
                </td>
                <td>
                    <input type="button" id="btnFind" value="Get Data From Local Storage" onclick="fnGetData()" />
                </td>
                <td>
                    <input type="button" value="abc" onclick="fnSaveData()" />
                </td>
            </tr>
        </table>
         <script>
             function fnSaveData() {
                 alert('hi');
                 localStorage.setItem("CustName", document.getElementById("txtCustomer").value);
                 localStorage.setItem("CustAddr", document.getElementById("txtCustAddr").value);

                 var p = localStorage.getItem("name");
                 alert(p);
                 
             }
         </script>
    </main>

</asp:Content>
