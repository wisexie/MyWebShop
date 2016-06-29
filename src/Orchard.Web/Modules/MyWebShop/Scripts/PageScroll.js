window.onload = window.onscroll = function() {

    var oTop = document.documentElement.scrollTop || document.body.scrollTop;

    //alert(oTop);

    if (oTop >= 800) {

        $('.h_nav_f1').show();
		
		
    } 
	
    else {

        $('.h_nav_f1').hide();

    }				

};


$(document).ready(function(){

    //  $(".ibar_main_panel ul li").each(function() {

    $(".ibar_main_panel ul li").hover(

		function () {

		    var ibarFunc = $(this).find("[data-ibar]").attr("data-ibar");
            
		    // console.log(ibarFunc)

		    if (ibarFunc == "ibarUser") {

		        $(this).find("[data-ibar='ibarUser']").fadeIn(300);

		    } else if (ibarFunc == "ibarShowBox") {

		        $(this).find("[data-ibar='ibarShowBox']").fadeIn();
		        $(this).find("[data-ibar='ibarShowBox']").stop().animate({"left": "-92","opacity":"1"}, 300);

		    }

		},
		function () {

		    $(this).find("[data-ibar='ibarUser']").fadeOut(300);
		    $(this).find("[data-ibar='ibarShowBox']").stop().animate(

				{"left": "-144px","opacity":"0"},

				300,

				function(){

				    $(this).fadeOut(300)

				}

			);

		}
	)


    $('.conMinute-hd ul li').click(function(){

        var cl = $('.conMinute-hd ul li').index(this);

        $('.conMinute-bd ul li').eq(cl).show().siblings().hide();

        $('.conMinute-hd ul li a').removeClass('on');

        $(this).find('a').addClass('on');

    });
})

$(".hotBuyDh-box").slide({
	
    mainCell:".hotBuyDh-bd ul",
	
    autoPage:true,
	
	
    effect:"leftLoop",
	
    autoPlay:true,
	
    vis:5,
	
    trigger:"click"
	
	
	
	
	
});


$(function(){

    $('.iglRibar-hd li').hover(function(){

        var cl = $('.iglRibar-hd li').index(this);

        $('.iglRibar-a li').eq(cl).show().siblings().hide();

        $('.iglRibar-hd li a').removeClass('on');

        $(this).find('a').addClass('on');

    });

});

jQuery(".hotGoods-box").slide({
	
    mainCell:".hotGoods-bd",
	
    autoPage:true,
	
    effect:"leftLoop",
	
    autoPlay:true,
	
    vis:3,
	
    trigger:"click"
	
	
});

	 
$(".ibar_mp_bottom").slide({
	 
    titCell:".mpbtn_qrcode,mpbtn_support,.mpbtn_support", 
	 
    type:"menu",
	 
    targetCell:".mp_qrcode,.mp_tooltip",
	  
    effect:"fade",
	  
    delayTime:300,
	  
    triggerTime:0,
	  
    returnDefault:true
	  
});
/*
 $("#hTopNav").slide({
	 
	 titCell:"#menu-caBg", 
	 
	 type:"menu",
	 
	  targetCell:".tan-menu",
	  
	  effect:"slideDown",
	  
	  delayTime:300,
	  
	  triggerTime:0,
	  
	  returnDefault:false,
	  
	  defaultPlay:false
	  
	  });*/
jQuery(".menu-box").slide({

    mainCell:".cart-bd ul",

    autoPage:true,

    effect:"leftLoop",

    vis:4,

    trigger:"click"

});
$(".tan-menu").hide();

$("#menu-caBg").hover(
	function(){

	    $(".tan-menu").fadeIn();

	},
	function(){
	    $(".tan-menu").fadeOut();
	}
)

