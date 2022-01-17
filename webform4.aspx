<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="WebForm4.aspx.cs" Inherits="hello.WebForm4" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form >
        <div class="login-box">
            
            <div class="login-logo" >
            <img src="dist/img/logo.png" class="logo" style="width:100%"/>    
            </div>
            <!-- /.login-logo -->
            

            <div class="login-box-body">

                <%--   <div class="form-group input-group">
                    <span class="input-group-addon"><i class="glyphicon glyphicon-user"></i></span>
                    <select id="ddlUserType" class="form-control" onchange="UserTypeChange();">
                        <option>--User Type--</option>
                        <option value="Admin">Admin</option>
                        <option value="Doctor">Doctor</option>
                        <option value="Reception">Reception</option>
                        <option value="Telecaller">Telecaller</option>
                    </select>
                </div>--%>
                <div class="form-group input-group">
                    <span class="input-group-addon"><i class="glyphicon glyphicon-user"></i></span>
                    <input class="form-control" type="text" id='USERNAME' placeholder="Username"  />
                </div>

                <div class="form-group input-group">
                    <span class="input-group-addon"><i class="glyphicon glyphicon-lock"></i></span>
                    <input id="PASSWORD" type="password" class="form-control" placeholder="Password" />

                </div>

                

                <div class="row">
                    <div class="col-xs-12">
                        <input type="submit" class="btn btn-primary btn-block btn-flat" value="Sign In" onclick="return userLogin();" />

                    </div>
                </div>

                <!-- /.social-auth-links -->

            </div>
            <!-- /.login-box-body -->
        </div>
    </form>

    <script>

     function userLogin() {
             {
                $.ajax({
                    type: "POST",
                    url: "WebForm4.aspx/UserLogin",
                    data: JSON.stringify({
                        USERNAME: $("#USERNAME").val(),
                        PASSWORD: $("#PASSWORD").val(),
                       
                    }),
                    contentType: "application/json; charset=utf-8",
                    dataType: "JSON",
                    success: function (response) {

                        if (response.d.toString() == 'y') {
                            location.href = "WebForm2.aspx";
                        }
                        else {
                            var ss = response.d.toString().split("/");
                            alert(ss[1]);
                        }
                    },
                    failure: function (response) {
                        console.log(response.d.toString());
                    }
                });

            }
            return false;
        }

    </script>

</asp:Content>
