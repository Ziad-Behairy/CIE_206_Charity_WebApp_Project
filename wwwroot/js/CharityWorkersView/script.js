/*global $, console, document*/



$(function () {

    'use strict';

    //// image upload ui
    var $imageupload = $('.imageupload');
    $imageupload.imageupload({
        allowedFormats: ["jpg", "jpeg", "png"],
    });

    //// details slider

    $('.slider-for').slick({
        rtl: false,
        slidesToShow: 1,
        slidesToScroll: 1,
        nextArrow: '<span class="prev arrow"><i class="fa  fa-angle-left" aria-hidden="true"></i></span>',
        prevArrow: '<span class="next arrow"><i class="fa  fa-angle-right" aria-hidden="true"></i></span>',
        fade: true,
        lazyLoad: 'ondemand',
        asNavFor: '.slider-nav'
    });
    $('.slider-nav').slick({
        rtl: false,
        slidesToShow: 5,
        slidesToScroll: 1,
        lazyLoad: 'ondemand',
        asNavFor: '.slider-for',
        dots: false,
        autoplay: true,
        autoplaySpeed: 4000,
        centerMode: false,
        focusOnSelect: true,
        centerPadding: '0px',
        arrows: false,
        responsive: [
            {
                breakpoint: 590,
                settings: {
                    slidesToShow: 5
                }
    }
  ]
    });


    //////// validate

    $("#aboutform").validate({
        rules: {
            aboutone: {
                required: true,
            },
            abouttwo: {
                required: true,
            },
            aboutthree: {
                required: true,
            }
        },
        highlight: function (element, errorClass) {
            $(element).addClass("error")
            //                    .removeClass( "error-input" );

        },
        unhighlight: function (element, errorClass, validClass) {
            $(element).removeClass("error")
        }
    });


    $("#loginform").validate({
        rules: {
            password: {
                required: true,
            },
            email: {
                required: true,
                email: true
            }
        },
        highlight: function (element, errorClass) {
            $(element).addClass("error")
            //                    .removeClass( "error-input" );

        },
        unhighlight: function (element, errorClass, validClass) {
            $(element).removeClass("error")
        }
    });

    $("#addform").validate({
        rules: {
            imagefile: {
                required: true,
            },
            data: {
                required: true,
            },
            itemName: {
                required: true,
            },
            user: {
                required: true,
            },
            address: {
                required: true,
            },
            addmsg: {
                required: true,
            },
            price: {
                required: true,
            }
        },
        highlight: function (element, errorClass) {
            $(element).addClass("error");
            $(element).parents('.imageupload').addClass("error");
            //                    .removeClass( "error-input" );

        },
        unhighlight: function (element, errorClass, validClass) {
            $(element).removeClass("error");
            $(element).parents('.imageupload').removeClass("error");
        }
    });


    $("#contactform").validate({
        rules: {
            phonenumber: {
                required: true,
                number: true
            },
            email: {
                required: true,
                email: true
            }
        },
        highlight: function (element, errorClass) {
            $(element).addClass("error");
            $(element).parents('.imageupload').addClass("error");
            //                    .removeClass( "error-input" );

        },
        unhighlight: function (element, errorClass, validClass) {
            $(element).removeClass("error");
            $(element).parents('.imageupload').removeClass("error");
        }
    });



    ///////// إحصائيات البيع

    var MONTHS = ['يناير', 'فبراير', 'مارس', 'أبريل', 'مايو', 'يونيو', 'يوليو', 'أغسطس', 'سبتمبر', 'أكتوبر', 'نوفمبر', 'ديسمبر']




;
    var config = {
        type: 'line',
        data: {
            labels: ['يناير', 'فبراير', 'مارس', 'أبريل', 'مايو'],
            datasets: [{
                label: ' المتوقع',
                backgroundColor: window.chartColors.green,
                borderColor: window.chartColors.green,
                data: [
						randomScalingFactor(),
						randomScalingFactor(),
						randomScalingFactor(),
						randomScalingFactor(),
						randomScalingFactor(),
						randomScalingFactor(),
						randomScalingFactor()
					],
                fill: false,
				}, {
                label: 'الفعلي ',
                fill: false,
                backgroundColor: window.chartColors.blue,
                borderColor: window.chartColors.blue,
                data: [
						randomScalingFactor(),
						randomScalingFactor(),
						randomScalingFactor(),
						randomScalingFactor(),
						randomScalingFactor(),
						randomScalingFactor(),
						randomScalingFactor()
					],
				}]
        },
        options: {
            responsive: true,
            tooltips: {
                mode: 'index',
                intersect: false,
            },
            hover: {
                mode: 'nearest',
                intersect: true
            },
            scales: {
                xAxes: [{
                    display: true,
                    scaleLabel: {
                        display: true,
                        labelString: 'الشهر'
                    }
					}],
                yAxes: [{
                    display: true,
                    scaleLabel: {
                        display: true,
                        labelString: 'العدد'
                    }
					}]
            }
        }
    };





    ///////// زيارات الذكور والإناث


    var MONTHS = ['يناير', 'فبراير', 'مارس', 'أبريل', 'مايو', 'يونيو', 'يوليو', 'أغسطس', 'سبتمبر', 'أكتوبر', 'نوفمبر', 'ديسمبر']
    var color = Chart.helpers.color;
    var horizontalBarChartData = {
        labels: ['يناير', 'فبراير', 'مارس', 'أبريل', 'مايو'],
        datasets: [{
            label: 'الاناث',
            backgroundColor: color(window.chartColors.red).alpha(0.5).rgbString(),
            borderColor: window.chartColors.red,
            borderWidth: 1,
            data: [
					randomScalingFactor(),
					randomScalingFactor(),
					randomScalingFactor(),
					randomScalingFactor(),
					randomScalingFactor(),
					randomScalingFactor(),
					randomScalingFactor()
				]
			}, {
            label: 'الذكور',
            backgroundColor: color(window.chartColors.blue).alpha(0.5).rgbString(),
            borderColor: window.chartColors.blue,
            data: [
					randomScalingFactor(),
					randomScalingFactor(),
					randomScalingFactor(),
					randomScalingFactor(),
					randomScalingFactor(),
					randomScalingFactor(),
					randomScalingFactor()
				]
			}]

    };

    
    //////// run charts
    
    window.onload = function () {
        var ctx2 = document.getElementById('canvastwo').getContext('2d');
        window.myHorizontalBar = new Chart(ctx2, {
            type: 'horizontalBar',
            data: horizontalBarChartData,
            options: {
                // Elements options apply to all of the options unless overridden in a dataset
                // In this case, we are setting the border of each horizontal bar to be 2px wide
                elements: {
                    rectangle: {
                        borderWidth: 2,
                    }
                },
                responsive: true,
                legend: {
                    position: 'right',
                }
            }
        });
        
    var ctx1 = document.getElementById('canvasone').getContext('2d');
        window.myLine = new Chart(ctx1, config);

    };



   

});