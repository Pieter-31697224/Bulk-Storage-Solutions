<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Help.aspx.cs" Inherits="Bulk_Storage_Solutions.Views.Help" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <h1>Functionality of this web application</h1>
        <hr />
        <br />
        <h2>Add New</h2>
        <hr />
        <br />
        <p> 
            Pages with the 'Add New' button creates a new object of what is displayed in the page. For example, to add a new Contract 
            navigate to the Contracts page. Click on the Add New button and a popup modal will appear to add a new Contract. Make sure to 
            populate all fields and to submit with the correct data and datatypes. A placeholder will be in the text box as example of what 
            needs to be entered in that text box. With a drop down list, just click on the small down arrow on the right side of the text box 
            and all the options provided will be displayed.
        </p>
        <hr />
        <br />
        <h2>Edit</h2>
        <hr />
        <br />
        <p>
            If you want to update a record, navigate to the relevant page in the Navbar, a table with records will be displayed. In each of 
            the records displayed in the table will be a edit button on the far right. Once that button is clicked a popup modal will be displayed
            with that records information. Update the attribute that you want to update then press save on the bottom of the modal. The record will now 
            be updated. Note the Client Storage Agreement Page (CSA tab in the Navbar) does not have edit functionality.
        </p>
        <hr />
        <br />
        <h2>Delete</h2>
        <hr />
        <br />
        <p> 
            If you wish to delete a record, navigate to the relevant page in the Navbar, a table with records will be displayed. In each of 
            the records displayed in the table will be a delete button on the far right. Once that button is clicked a popup modal will displayed to prompt 
            the user if he/she wishes to delete that record. Once the delete option has been clicked in the popup modal the record will be deleted.
        </p>
        <hr />
        <br />
        <h2>Search</h2>
        <hr />
        <br />
        <p>
            Every page has a extensive search function. The search bar and search button will appear on the top of every page. You can then search
            for anything, but remember that the more detailed your search is the more detailed the response will be. After entering the search 
            criteria in the search bar remember to click the search button, it is this action the does the search.  
        </p>
        <hr />
        <br />
        <h2>Reports</h2>
        <hr />
        <br />
        <p> 
            The Reports page is the only page that does not have any CRUD functionality (Create, Read, Update and Delete). Every report in 
            this page has a drop down list to choose how the chart should look. Once you have selected the chart you wish to display make sure to click 
            the apply button next to the drop down list. Once the apply button has been clicked the report will update to the selected chart type. Some of 
            the reports has a search functionality. After entering your desired search criteria make sure to click the search button next to the search area.
        </p>
    </div>
</asp:Content>
