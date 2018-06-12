
/*var modelView = {
    Products: ko.observableArray([]),
    viewProducts: function () {
        var thisObj = this;
        try {
            $.ajax({
                url: '/Products/GetAllProducts',
                type: 'GET',
                dataType: 'json',
                contentType: 'application/json',
                success: function (data) {
                    thisObj.Products(data); //Here we are assigning values to KO Observable array
                },
                error: function (err) {
                    alert(err.status + " : " + err.statusText);
                }
            });
        } catch (e) {
            window.location.href = '/Products/Index/';
        }
    }
};
$(function () {
    ko.applyBindings(modelView);
    modelView.viewProducts();
});
function ProductViewModel() {

    //Make the self as 'this' reference
    var self = this;
    //Declare observable which will be bind with UI
    self.Id = ko.observable("");
    self.Name = ko.observable("");
    self.Price = ko.observable("");


    var Product = {
        Id: self.Id,
        Name: self.Name,
        Price: self.Price,
      
    };

    self.Product = ko.observable();
   // self.Products = ko.observableArray(); // Contains the list of products
    self.Products = ko.observableArray([
        { Name: 'Milk' },
        { Name: 'Oil' },
        { Name: 'Shampoo' }
    ]);
    // Initialize the view-model
    $.ajax({
        url: 'Products/GetAllProducts',
        cache: false,
        type: 'GET',
        contentType: 'application/json; charset=utf-8',
        data: {},
        success: function (data) {
            self.Products(data); //Put the response in ObservableArray
        }
    });

    // Calculate Total of Price After Initialization
   
}
<script src="~/Scripts/KORead.js"></script>

var viewModel = new ProductViewModel();
ko.applyBindings(viewModel);*/
function AppViewModel() {
    this.firstName = ko.observable("Bert");
    this.lastName = ko.observable("Bertington");

    this.fullName = ko.computed(function () {
        return this.firstName() + " " + this.lastName();
    }, this);
}



            $(document).ready(function () {
               
            ko.applyBindings(new AppViewModel());
        })
