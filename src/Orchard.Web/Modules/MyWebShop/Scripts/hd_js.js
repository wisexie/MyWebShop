
$(function(){
	
	//�������
	
    var nav = $(".home-baokuang");//����װ
	
    var init = $(".bk_tab span").eq(ind);//���Ŀ��
	
    var block = $(".home-baokuang .tab-arrow");//����
	
    block.css({
		
        "left": init.position().left - 3
		
    });
	
    nav.click(function() {},
	
	
    function() {
		
        block.stop().animate({
			
            "left": init.position().left - 3//����
			
        },
		
        100);
		
    });
	
	//�����˵�
	
    $(".home-baokuang").slide({//����װ
	
	
        type: "menu",//�˵�ģʽ
		
		
        titCell: ".bk_tab span",//���Ŀ��
		
		
    <!--    targetCell: ".sub",//Ӱ������ʾ  -->
		
		
        delayTime: 100,//�ӳ�ʱ��
		
		
        triggerTime: 300,//ͣ��ʱ��
		
		
		speed: 500,//�ٶ�
		
		
        returnDefault: true,//����Ĭ��ֵ
		
		
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

//����

myFocus.set({
	
	id:'myFocus',//ID
	
	pattern:'mF_quwan'//���
	
});
