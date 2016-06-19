
$(function(){
	
	//滑块跟随
	
    var nav = $(".home-baokuang");//外层包装
	
    var init = $(".bk_tab span").eq(ind);//鼠标目标
	
    var block = $(".home-baokuang .tab-arrow");//滑块
	
    block.css({
		
        "left": init.position().left - 3
		
    });
	
    nav.click(function() {},
	
	
    function() {
		
        block.stop().animate({
			
            "left": init.position().left - 3//滑动
			
        },
		
        100);
		
    });
	
	//下拉菜单
	
    $(".home-baokuang").slide({//外层包装
	
	
        type: "menu",//菜单模式
		
		
        titCell: ".bk_tab span",//鼠标目标
		
		
    <!--    targetCell: ".sub",//影藏与显示  -->
		
		
        delayTime: 100,//延迟时间
		
		
        triggerTime: 300,//停留时间
		
		
		speed: 500,//速度
		
		
        returnDefault: true,//返回默认值
		
		
        defaultIndex: ind,
		
		
        startFun: function(i, c, s, tit) {
			
			
            block.stop().animate({
				
				
                "left": tit.eq(i).position().left - 3
				
            },
			
            100);
			
        }
		
    });
	
});

var ind = 0;

//设置

myFocus.set({
	
	id:'myFocus',//ID
	
	pattern:'mF_quwan'//风格
	
});
