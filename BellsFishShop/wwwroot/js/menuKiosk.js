//setInterval(function () {
//    let width = $(window).width() * 2;
//    $(".body-content").animate({ "marginLeft": "-" + width + "px" }, "slow", function () {/*animate off screen left*/
//        setTimeout(function () {
//            $(".body-content").css({ "marginLeft": width + "px" });/*set to off screen right*/
//            $(".body-content").animate({ "marginLeft": "0px" }, "slow"); /*animate in from right back to zero*/
//        }, 1000);
//    });
//}, 10000); 


function animateMenu() {
    setTimeout(function () {
        let width = $(window).width() * 2;
        let margin = $(".Menu").css("margin-left");
        $(".Menu").animate({ "marginLeft": "-" + width + "px" }, "slow", function () {/*animate off screen left*/
            setTimeout(function () {
                let logoAnim = $("#BellsLogoLargeAnimation .BellsLogoLarge");
                logoAnim.addClass("show");
                setTimeout(function () {
                    //logoAnim.removeClass("show");
                    logoAnim.addClass("hide");
                    setTimeout(function () {
                        $(".Menu").css({ "marginLeft": width + "px" });/*set to off screen right*/
                        $(".Menu").animate({ "marginLeft": margin }, "slow"); /*animate in from right back to zero*/
                        logoAnim.removeClass("show");
                        logoAnim.removeClass("hide");
                        animateMenu();
                    }, 500);
                }, 5000);
            }, 500);
        });
    }, 20000);
}

animateMenu();