$(function () {
    return $(".carousel.lazy").on("slide.bs.carousel", function (ev) {
        var lazy;
        lazy = $(ev.relatedTarget).find("img[data-src]");
        lazy.attr("src", lazy.data('src'));
        lazy.removeAttr("data-src");
    });
});

//Make Twitter Feed Responsive 100% Height
$(window).on('resize', function () {
    setTimeout(function () { changeFBPagePlugin(); }, 500);
});

$(window).on('load', function () {
    setTimeout(function () { changeFBPagePlugin(); }, 1000);
});

changeFBPagePlugin = function () {
    var container_height = Number($('.ContentBesideTwitter').height()).toFixed(0);
    if (!isNaN(container_height)) {
        $(".Twitter").height(container_height);
        $(".TwitterPlaceholder").hide();
        $(".Twitter").show();
    }
};

function checkScroll() {
    var startY = $('.navbar').height() * 2; //The point where the navbar changes in px

    if ($(window).scrollTop() > startY) {
        $('.navbar').addClass("scrolled");
    } else {
        $('.navbar').removeClass("scrolled");
    }
}

if ($('.navbar').length > 0) {
    $(window).on("scroll load resize", function () {
        checkScroll();
    });
}

//// init controller
//var controller = new ScrollMagic.Controller({ globalSceneOptions: { duration: 2000 } });

//// build scene
//var scene1 = new ScrollMagic.Scene({
//    triggerElement: ".NavbarLogoTrigger",
//    duration: "100%"
//})
//    // trigger animation by adding a css class
//    .setClassToggle("#NavbarLogo", "NavbarLogoAnimate")
//    .on('start', function () {
//        //this.triggerElement()
//        animateNavbarIcon();
//    })
//    //.addIndicators({ name: "Navbar Logo" })
//    .addTo(controller);

//function animateNavbarIcon() {
//    $('#NavbarLogo').css({
//        "borderSpacing": "0",
//        "transform": "rotate(-90deg)"
//    });

//    $("#NavbarLogo").animate({
//        borderSpacing: 90
//    },
//    {
//        step: function (now, fx) {
//            $(this).css('transform', 'rotate(' + now + 'deg)');
//        },
//        duration: 500
//    }, 'linear');
//}

var SendEnquiryButtons = document.querySelectorAll('.SendEnquiry');
Array.from(SendEnquiryButtons).forEach(button => {
    button.addEventListener("click", function (event) {
        event.preventDefault();

        let antiForgeryTokenID = document.querySelector("#AntiForgeryTokenID").value;
        doContactForm(antiForgeryTokenID);
    });
});

function doContactForm(antiForgeryTokenID) {
    return new Promise(resolve => {
        let contactURL = "";

        contactURL = `/Contact`;

        $.ajax({
            type: "POST",
            url: contactURL,
            beforeSend: function (xhr) {
                xhr.setRequestHeader("RequestVerificationToken", antiForgeryTokenID);
            },
            data: $("#ContactForm").serialize(),
            //data: {
            //    'Contact.Name': "robin",
            //    'Contact.Email': "robinwilson@rwsbetas.com",
            //    'Contact.Telephone': "07732439335",
            //    'Contact.Enquiry': "Test",
            //    '__RequestVerificationToken': antiForgeryTokenID
            //},
            success: function (data) {
                //var audio = new Audio("/sounds/confirm.wav");
                //audio.play();
                let result = $(data).find(".alert");
                let isSuccess = result.hasClass("alert-success");

                let ContactForm = document.querySelector("#ContactForm");
                let msg = document.createElement('div');

                if (isSuccess === true) {
                    msg.setAttribute("class", "alert alert-success");
                }
                else {
                    msg.setAttribute("class", "alert alert-danger");
                }
                
                msg.setAttribute("role", "alert");
                msg.innerHTML = result.html();

                ContactForm.parentNode.insertBefore(msg, ContactForm.nextSibling);

                console.log(`Message sent successfully`);
                resolve(1);
            },
            error: function (error) {
                doCrashModal(error);
                console.log(`Error occurred: "${error}"`);
                resolve(0);
            }
        });
    });
}

$("#MenuCategoryModal").on("shown.bs.modal", function () {
    let menuCategoryID = $("#MenuCategoryID").val();
    
    loadMenuCategoryForm(menuCategoryID);
    loadMenuItemList(menuCategoryID);
});

function loadMenuCategoryForm(menuCategoryID) {
    let dataToLoad = `/MenuCategoryData/Edit/${menuCategoryID}`;

    $.get(dataToLoad, function (data) {

    })
        .then(data => {
            let formData = $(data).find("#MenuCategoryForm");
            $("#MenuDetails").html(formData);
            console.log(dataToLoad + " Loaded");
            menuCategoryLoadComplete(menuCategoryID, "MenuCategoryData", "MenuCategoryModal");
        })
        .fail(function () {
            let title = `Error Loading Menu Category Form`;
            let content = `The menu category form returned a server error and could not be loaded`;

            doErrorModal(title, content);
        });
}

function loadMenuItemList(menuCategoryID) {
    dataToLoad = `/MenuItemData/${menuCategoryID}`;

    $.get(dataToLoad, function (data) {

    })
        .then(data => {
            let formData = $(data).find("#MenuItemList");
            $("#MenuItems").html(formData);
            console.log(dataToLoad + " Loaded");
            menuItemListLoadComplete(menuCategoryID, "MenuItemData", "MenuItemModal");
        })
        .fail(function () {
            let title = `Error Loading Menu Category Items`;
            let content = `The menu category items list returned a server error and could not be loaded`;

            doErrorModal(title, content);
        });
}

$("#MenuItemModal").on("shown.bs.modal", function () {
    let menuItemID = $("#MenuItemID").val();
    loadMenuItemForm(menuItemID);
});

function loadMenuItemForm(menuItemID) {
    let dataToLoad = `/MenuItemData/Edit/${menuItemID}`;

    $.get(dataToLoad, function (data) {

    })
        .then(data => {
            let formData = $(data).find("#MenuItemForm");
            $("#MenuItemDetails").html(formData);
            console.log(dataToLoad + " Loaded");
            menuItemLoadComplete(menuItemID, "MenuItemData", "MenuItemModal");
        })
        .fail(function () {
            let title = `Error Loading Menu Item Form`;
            let content = `The menu item form returned a server error and could not be loaded`;

            doErrorModal(title, content);
        });
}

$("#MenuCategoryModal").on("hidden.bs.modal", function () {
    $("#MenuTabs a:first").tab("show");
    let loadingAnim = $("#LoadingHTML").html();
    $("#MenuDetails").html(loadingAnim);
    $("#MenuItems").html(loadingAnim);
});

$("#MenuItemModal").on("hidden.bs.modal", function () {
    let loadingAnim = $("#LoadingHTML").html();
    $("#MenuItemDetails").html(loadingAnim);
});

