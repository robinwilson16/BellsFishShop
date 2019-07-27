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
        $(".body-content").animate({ "marginLeft": "-" + width + "px" }, "slow", function () {/*animate off screen left*/
            setTimeout(function () {
                $(".body-content").css({ "marginLeft": width + "px" });/*set to off screen right*/
                $(".body-content").animate({ "marginLeft": "0px" }, "slow"); /*animate in from right back to zero*/
                animateMenu();
            }, 500);
        });
    }, 20000);
}

animateMenu();