var swiperprodDet = new Swiper(".mySwiperProdDetailRelated", {
	slidesPerView: 4,
    loop: true,
	navigation: {
	  nextEl: ".swiper-button-next-rel",
	  prevEl: ".swiper-button-prev-rel",
	}, breakpoints: {
		1200: {
			slidesPerView: 4,
			spaceBetween: 0
		},
		991: {
			slidesPerView: 2,
			spaceBetween: 0
		},
		0: {
			slidesPerView: 1,
			spaceBetween: 0
		}
	}
	});
var swiperprodDet = new Swiper(".mySwiperProdDetailRecently", {
	slidesPerView: 4,
	loop: true,
	navigation: {
		nextEl: ".swiper-button-next-rect",
		prevEl: ".swiper-button-prev-rect",
	}, breakpoints: {
		1200: {
			slidesPerView: 4,
			spaceBetween: 0
		},
		991: {
			slidesPerView: 2,
			spaceBetween: 0
		},
		0: {
			slidesPerView: 1,
			spaceBetween: 0
		}
	}
});
var swiperprodDet = new Swiper(".mySwiperProdDetailRecommended", {
	slidesPerView: 4,
	loop: true,
	navigation: {
		nextEl: ".swiper-button-next-recm",
		prevEl: ".swiper-button-prev-recm",
	}, breakpoints: {
		1200: {
			slidesPerView: 4,
			spaceBetween: 0
		},
		991: {
			slidesPerView: 2,
			spaceBetween: 0
		},
		0: {
			slidesPerView: 1,
			spaceBetween: 0
		}
	}
});
// Swiper slider
var swiperSmallImage = new Swiper(".mySwiperSmallImg", {
		spaceBetween: 0,
	slidesPerView: 3,
	freeMode: false,
	clickable: true,
	watchSlidesProgress: true,
	  });
var swiperBigImage = new Swiper(".mySwiperBigImg", {
	  cssMode: true,
		spaceBetween: 10,
		navigation: {
		  nextEl: "",
		  prevEl: "",
		},
		thumbs: {
			swiper: swiperSmallImage,
		},
		});

	$(document).ready(function(){
		// PRODUCT DETAIL---->

 // Image on hover move
 var X = 0;
 var Y = 0;
 $(".image-b img").mouseover(function(en){
	 $(this).css({
	 "opacity" : "0"
	 })
	 X=210;
	 Y=355;
	 $(this).parent().css({
	 "background-image" :`url(${this.src})`,
	 "background-position" : `${X}px ${Y}px`,
	"background-repeat": "no-repeat",
	"background-size": "cover",
	 "transform" : "scale(1.4)",
	 "transition" : "all 0s"
	 })
	 $(this).mousemove(function(e){
	 $(this).parent().css({
		 "background-image" :`url(${this.src})`,
		 "background-position" : `${X-e.pageX/2}px ${Y-e.pageY/2}px`,
		 "transform" : "scale(1.4)",
		 "transition" : "all 0s"
	 })
	 })
	 $(".image-b img").mouseleave(function(){
		 $(this).css({
		 "opacity" : "1"
		 })
		 $(this).parent().css({
		 "background-image" :`url(${this.src})`,
		 "background-position" : `${X}px ${Y}px`,
		 "transform" : "scale(1)",
		 "transition" : "all 0s"
		 })
	 })
 })
	})