$(document).ready(function(){
    // detect mobile
    if( /Android|webOS|iPhone|iPad|BlackBerry|IEMobile|Opera Mini/i.test(navigator.userAgent) ){
        $('body').addClass('mobile');
    }
	// detect ipod
	if( /iPod/i.test(navigator.userAgent) ){
		$('body').addClass('ipod');
	} 
    // slider
    $('.block-main-slider').slider();
    // faq
    $('.faq').tabs();
    // form
    $('form').forms();
    // show plans
    $('.block-show-plans').showPlans();
    // tables
    $('.table-container').tableContainers();
});
(function( $ ){
    $.fn.tableContainers = function(){
        var container = $(this);
		
        container.find('.row').click(function(){
            var row = $(this);
            var input = row.find('.description input').prop("checked");

			/*if(input == false){
				row.find('.description input').addClass('active').prop("checked", true );
			}else{
				row.find('.description input').addClass('active').prop("checked", false );
			}
			
			row.find('input').change(function(){
				if(row.find('.description input').prop("checked") == false){
					row.find('.description input').addClass('active').prop("checked", true ); 
				}else{
					row.find('.description input').addClass('active').prop("checked", false ); 
				}				
			});	
			*/
        });
    }

    $.fn.showPlans = function(){
        var title = $(this);
        var container = $('.block-show-plans-container');

        title.click(function(){
            if(!$(this).hasClass('active')){
                title.addClass('active');
                container.slideDown('200');
            }else{
                title.removeClass('active');
                container.slideUp('200');
            }
        });

    }

    $.fn.forms = function(){
        /* style form */
        var form = $(this);

        /* style form inputs */
        form.find('.item-text').each(function(){
            var item = $(this);

            /* get width */
            var itemWidth = item.width();
            var labelWidth = item.find('label').outerWidth() + 3;
            var inputWidth = item.find('input').outerWidth();
            var padding = parseInt(item.find('input').css('padding'));
            var newInputWidth = inputWidth + ( itemWidth - labelWidth - inputWidth ) - padding * 2;

            item.find('input').width(newInputWidth);
        });
        /* style select */
        form.find('.item-select').each(function(){
            var item = $(this);

            /* get width */
            var itemWidth = item.width();
            var labelWidth = item.find('label').outerWidth() - 1;
            var inputWidth = item.find('select').outerWidth();
            var padding = parseInt(item.find('select').css('padding'));
            var newInputWidth = inputWidth + ( itemWidth - labelWidth - inputWidth ) - padding * 2;

            item.find('select').width(newInputWidth);
        });
        /* add class active */
        form.find('input.input-text, textarea, select').focus(function(){
            $(this).parent().addClass('active');
        });
        /* remove active class */
        form.find('input.input-text, textarea, select').focusout(function(){
            $(this).parent().removeClass('active');
        });
		/* click on textarea */
		form.find('.item-textarea .header').click(function(){
			var container = $(this).parent();
			
			container.find('textarea').focus();
		});
    };

    $.fn.tabs = function(){
        /* tabs for faq page */
        var container = $(this);
        container.find('.item .title').click(function(){
            var item = $(this).parent().parent();
            if(!item.hasClass('active')){
                item.find('.text').slideDown(0,function(){
                    var height = item.height() - 50;
                    item.addClass('active');
                    item.find('.line').height(height);
                });

            }else{
                item.find('.text').slideUp();
                item.removeClass('active');
                item.find('.line').height(0);
            }
        });
    };

    $.fn.slider = function(){
        /* slider for main page */
        var container = $(this);
        var navigation = container.find('.navigation');
        var intervalId;

        navigation.find('.round').click(function(){

            /* stop timer */
            clearInterval(intervalId);
            var id = $(this).attr('data-container-id');
            var imageContainer = $('#'+id);

            if(!imageContainer.hasClass('active')){

                navigation.find('.active').removeClass('active');
                $(this).addClass('active');

                container.find('.image .active').fadeOut(300).removeClass('active');
                imageContainer.fadeIn(300).addClass('active');
            }
            intervalId = setInterval( automaticSlider , 12000);
        });
        /* start slider automatic */
        intervalId = setInterval( automaticSlider , 12000);
    };
})( jQuery );

function automaticSlider(){
    /* start automatic slider */
    var navigation = $('.block-main-slider .navigation');

    var activeSlide = navigation.find('.active');
    var number = activeSlide.attr('data-number');
    var id = activeSlide.attr('data-container-id');

    var next = parseInt(number) + 1;
    if(number == navigation.find('.round').size()){
        next = 1;
    }
    var nextId = $('#round-'+next).attr('data-container-id');

    navigation.find('.active').removeClass('active');
    $('#round-'+next).addClass('active');
    $('#'+id).fadeOut(300).removeClass('active');
    $('#'+nextId).fadeIn(300).addClass('active');
}