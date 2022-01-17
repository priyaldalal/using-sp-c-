<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="WebForm2.aspx.cs" Inherits="hello.WebForm2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="col-md-6 grid-margin stretch-card">
        <div class="card">
            <div class="card-body">
                <h4 class="card-title">Default form</h4>
                <p class="card-description">
                    Basic form layout
                 
                </p>
                <form class="forms-sample">
                    <div class="form-group">
                        <label for="exampleInputUsername1">USERID</label>
                        <input type="number" class="form-control" id="USERID" placeholder="UserID" disabled>
                    </div>
                    <div class="form-group">
                        <label for="exampleInputUsername1">Username</label>
                        <input type="text" class="form-control" id="USERNAME" placeholder="Username">
                    </div>
                    <div class="form-group">
                        <label for="exampleInputEmail1">Email address</label>
                        <input type="email" class="form-control" id="EMAIL" placeholder="Email">
                    </div>
                    <div class="form-group">
                        <label for="exampleInputPassword1">Password</label>
                        <input type="password" class="form-control" id="PASSWORD" placeholder="Password">
                    </div>
                    <div class="form-group">
                        <label for="exampleInputConfirmPassword1">Confirm Password</label>
                        <input type="password" class="form-control" id="CPPASSWORD" placeholder="Password">
                    </div>
                    <div class="form-check form-check-flat form-check-primary">
                        <!-- <label class="form-check-label">
                        <input type="checkbox" class="form-check-input">
                        Remember me
                      </label>-->
                    </div>
                    <button type="button" class="btn btn-primary mr-2" onclick="CallClientToServer();">Submit</button>
                    <button type="button" class="btn btn-light" onclick="CallUPDATE();">update</button>
                    <button type="button" class="btn btn-light" onclick="CALLDELETE();">DELETE</button>
                </form>

            </div>
        </div>

        <table class="table" id="tblData">
            <thead>
                <tr>
                    <th>Action</th>
                    <th>USERNAME</th>
                    <th>EMAIL</th>
                    <th>PASWORD</th>

                </tr>
            </thead>
            <tbody>
            </tbody>
        </table>
    </div>

    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
    <script type="text/javascript">
        function CallClientToServer() {
            $.ajax({
                type: "POST",
                url: "WebForm2.aspx/Save",
                data: JSON.stringify({ USERNAME: $("#USERNAME").val(), EMAIL: $("#EMAIL").val(), PASSWORD: $("#PASSWORD").val() }),
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: OnSuccess,
                failure: function (response) {
                    alert(response.d);
                }
            });
        }
        function OnSuccess(response) {
            alert(response.d);
        }
        function GETALL() {
            $.ajax({
                type: "POST",
                url: "WebForm2.aspx/GetAll",

                contentType: "application/json; charset=utf-8",
                dataType: "JSON",
                //data: postdata,
                success: function (response) {
                    var datatable = $("#tblData tbody").empty();
                    $(response.d).find("tblData").each(function () {

                        var USERNAME = $(this).find("USERNAME").text();
                        var EMAIL = $(this).find("EMAIL").text();
                        var PASSWORD = $(this).find("PASSWORD").text();
                        var USERID = $(this).find("ID").text();
                        var viewbtn = "<input type='button' onclick='GETDETAIL(\"" + USERID + "\")' value='View'>";

                        var row = $("<tr><td>" + viewbtn + "</td><td>" + USERNAME + "</td><td>" + EMAIL + "</td><td>" + PASSWORD + "</td></tr>")
                        $(datatable).append(row);
                    });
                },
                failure: function (response) {

                }
            });
        }


        function GETDETAIL(_USERID) {
            $.ajax({
                type: "POST",
                url: "WebForm2.aspx/GETDETAIL",
                data: JSON.stringify({ userid: _USERID }),
                contentType: "application/json; charset=utf-8",
                dataType: "JSON",
                //data: postdata,
                success: function (response) {
                    $(response.d).find("tblData").each(function () {

                        var USERNAME = $(this).find("USERNAME").text();
                        var EMAIL = $(this).find("EMAIL").text();
                        var PASSWORD = $(this).find("PASSWORD").text();
                        var USERID = $(this).find("ID").text();

                        $("#USERNAME").val(USERNAME);
                        $("#EMAIL").val(EMAIL);
                        $("#PASSWORD").val(PASSWORD);
                        $("#USERID").val(USERID);
                    });
                },
                failure: function (response) {

                }
            });
        }

        
        function CallUPDATE() {
            $.ajax({
                type: "POST",
                url: "WebForm2.aspx/UPDATE",
                data: JSON.stringify({ USERID: $("#USERID").val(), USERNAME: $("#USERNAME").val(), EMAIL: $("#EMAIL").val(), PASSWORD: $("#PASSWORD").val() }),
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {
                    alert(response.d);
                    GETALL();
                    $("#USERID").val(),  $("#USERNAME").val(),  $("#EMAIL").val(), $("#PASSWORD").val()
                },
                failure: function (response) {
                    alert(response.d);
                }
            });
        }
        function OnSuccess(response) {
            alert(response.d);
        }


        function CALLDELETE() {
            $.ajax({
                type: "POST",
                url: "WebForm2.aspx/DELETE",
                data: JSON.stringify({ USERID: $("#USERID").val() }),
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {
                    alert(response.d);
                    GETALL();
                    $("#USERID").val(), $("#USERNAME").val(), $("#EMAIL").val(), $("#PASSWORD").val()
                },
                failure: function (response) {
                    alert(response.d);
                }
            });
        }
        function OnSuccess(response) {
            alert(response.d);
        }
       

    </script>
    <script type="text/javascript">
        $(document).ready(function () {
            GETALL();
        });
    </script>

</asp:Content>
