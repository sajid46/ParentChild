<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="DataTransformation_XMLWeb._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">




<%--<asp:ScriptManager ID="id1" runat="server" EnablePageMethods="true"></asp:ScriptManager>	--%>
	
    <%

//private const string Uri = "C:/Projects/Tutorial Projects/Tutorials/DataTransformation_XMLWeb/XSLTClient/StudentsXML.xml";
//static XDocument xDocument = XDocument.Load(Uri);



//List<string> o = xDocument.Descendants("Student").Select(x =>
//	new
//	{
//		name = x.Element("Name").Value
//	}).ToList();





		%>
<script>
	function fn() {
		PageMethods.GetTime(OnSuccess, OnError);
	}

	function OnSuccess(response, userContext, methodName) {
		alert("Response: " + response);
	}

	function OnError() {
		alert("Error");
	}

</script>
</asp:Content>
