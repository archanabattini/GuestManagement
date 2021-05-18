
function GuestViewModel() {

    //Make the self as 'this' reference
    var self = this;
    //Declare observable which will be bind with UI
    self.GuestId = ko.observable("");
    self.FirstName = ko.observable("");
    self.LastName = ko.observable("");
    self.Email = ko.observable("");
    self.PhoneNumber = ko.observable("");


    var Guest = {
        GuestId: self.GuestId,
        FirstName: self.FirstName,
        LastName: self.LastName,
        Email: self.Email,
        PhoneNumber: self.PhoneNumber
    };

    self.Guest = ko.observable();
    self.Guests = ko.observableArray(); // Contains the list of Guests

    // Initialize the view-model
    if (window.location.href.indexOf("/Edit/") != -1) {
        var _guestId = window.location.href.substring(window.location.href.lastIndexOf("/") + 1);
        $.ajax({
            url: '/Guests/GetGuest/' + _guestId,
            cache: false,
            type: 'GET',
            contentType: 'application/json; charset=utf-8',
            data: {},
            success: function (data) {
                self.FirstName(data.FirstName);
                self.GuestId(data.GuestId);
                self.LastName(data.LastName);
                self.Email(data.Email);
                self.PhoneNumber(data.PhoneNumber);
                self.Guest(data);
            }
        });
    } else {
        $.ajax({
            url: 'Get',
            cache: false,
            type: 'GET',
            contentType: 'application/json; charset=utf-8',
            data: {},
            success: function (data) {
                self.Guests(data); //Put the response in ObservableArray
            }
        });
    }

    //Add New Guest
    self.create = function () {
        if (Guest.FirstName() != "" && Guest.LastName() != ""
            && Guest.Email() != "") {
            Guest.GuestId("");
            var _guest = JSON.parse(ko.toJSON(Guest));
            delete _guest.GuestId;
            $("div.spanner").addClass("show");
            $("div.overlay").addClass("show");
            $.ajax({
                url: 'Create',
                cache: false,
                type: 'POST',
                dataType: 'json',
                data: _guest,
                success: function (data) {
                    //Redirects to Guests page.
                    self.redirectToHome();
                }
            }).fail(
                function (xhr, textStatus, err) {
                    self.processErrors(xhr);
                    $("div.spanner").removeClass("show");
                    $("div.overlay").removeClass("show");
                });
        }
        else {
            /*alert('Please Enter All the Values !!');*/
        }
    }

    self.edit = function (Guest, event) {
        window.location.href = event.currentTarget.attributes.url.value + '/' + Guest.GuestId;
    }

    self.manage = function() {
        if (Guest.GuestId() > 0) {
            self.update();
        } else {
            self.create();
        }
    }

    // Edit a Guest
    self.update = function () {
        var _guest = ko.toJSON(Guest);
        $("div.spanner2").addClass("show");
        $("div.overlay").addClass("show");
        $.ajax({
            url: '/Guests/Edit',
            cache: false,
            type: 'POST',
            data: JSON.parse(_guest),
            success: function (data) {
                //Redirects to Guests page.
                self.redirectToHome();
            }
        }).fail(
            function (xhr, textStatus, err) {
                self.processErrors(xhr);
                $("div.spanner2").removeClass("show");
                $("div.overlay").removeClass("show");
            });
    }

    // Cancel Create/Edit
    self.cancel = function () {
        self.Guest(null);
        self.redirectToHome();
    }

    self.processErrors = function (xhr) {
        var _errors = xhr.responseJSON;
        $.each(_errors, function (_index, _element) {
            if (_element.length > 0) {
                if ($("#" + _index + "Errors")) {
                    $("#" + _index + "Errors").text(_element[0]);
                    $("#" + _index + "Errors").addClass("text-danger");
                    $("#" + _index).removeClass("is-valid");
                    $("#" + _index).addClass("is-invalid");
                }
            } else {
                if ($("#" + _index + "Errors")) {
                    $("#" + _index + "Errors").text('');
                    $("#" + _index + "Errors").removeClass("text-danger");
                    $("#" + _index).removeClass("is-invalid");
                    $("#" + _index).addClass("is-valid");
                }
            }

        });
        if (xhr.responseText && !_errors) {
            $(".alert-main").text(xhr.responseText);
            $(".alert-main").removeClass("alert-success");
            $(".alert-main").addClass("alert-danger");
        } else if (!_errors) {
            $(".alert-main").text('');
            $(".alert-main").removeClass("alert-success");
            $(".alert-main").removeClass("alert-danger");
        }
    }

    self.redirectToHome = function () {
        window.location.href = "/Guests/Index";
    }
}
$(document).ready(function () {
    var viewModel = new GuestViewModel();
    ko.applyBindings(viewModel);
});
