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

// init controller
var controller = new ScrollMagic.Controller({ globalSceneOptions: { duration: 2000 } });

// build scene
var scene1 = new ScrollMagic.Scene({
    triggerElement: ".NavbarLogoTrigger",
    duration: "100%"
})
    // trigger animation by adding a css class
    .setClassToggle("#NavbarLogo", "NavbarLogoAnimate")
    .on('start', function () {
        //this.triggerElement()
        animateNavbarIcon();
    })
    //.addIndicators({ name: "Navbar Logo" })
    .addTo(controller);

function animateNavbarIcon() {
    $('#NavbarLogo').css({
        "borderSpacing": "0",
        "transform": "rotate(-90deg)"
    });

    $("#NavbarLogo").animate({
        borderSpacing: 90
    },
    {
        step: function (now, fx) {
            $(this).css('transform', 'rotate(' + now + 'deg)');
        },
        duration: 500
    }, 'linear');
}