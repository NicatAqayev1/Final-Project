
$(document).ready(function () {
	if (JSON.parse(localStorage.getItem("modal")) === null) {
		$(".overlay-first-modal").css({
			"opacity": "1",
			"visibility": "visible",
			"z-index": "99999"
		})
		$(".modal-close-icon").parent().css({
			"opacity": "1",
			"visibility": "visible",
			"z-index": "99999"
		})
	}
	// Phone menu
	$(".up-icon").click(function () {
		$(".down-icon").hide();
		$(".up-icon").show();
		$(this).hide();
		$(this).next().show();
		$(".nav-toggle").removeClass("active-ul");
		$(this).next().next().addClass("active-ul");
		$(".head-text").css("color", "#253D4E");
		$(this).prev().css("color", "#b73b3b");
	});
	$(".down-icon").click(function () {
		$(this).hide();
		$(this).prev().show();
		$(this).next().removeClass("active-ul");
		$(this).prev().prev().css("color", "#253D4E");
	});
	$(".up-icon2").click(function () {
		$(".down-icon2").hide();
		$(".up-icon2").show();
		$(this).hide();
		$(this).next().show();
		$(".nav-toggle2").removeClass("active-ul");
		$(this).next().next().addClass("active-ul");
		$(".head-text2").css("color", "#253D4E");
		$(this).prev().css("color", "#b73b3b");
	});
	$(".down-icon2").click(function () {
		$(this).hide();
		$(this).prev().show();
		$(this).next().removeClass("active-ul");
		$(this).prev().prev().css("color", "#253D4E");
	});

	// Side-bar menu
	$(".burger").click(function () {
		// open
		$(".phone-side-menu").css({
			opacity: "1",
			visibility: "visible",
			transform: "translateX(0px)",
		});
		$(".overlay-cart").css({
			opacity: "1",
			visibility: "visible",
		});
	});
	// close
	$(".sidebar-close-icon").click(function () {
		$(".phone-side-menu").css({
			opacity: "0",
			visibility: "hidden",
			transform: "translateX(-200px)",
		});
		$(".overlay-cart").css({
			opacity: "0",
			visibility: "hidden",
		});
	});
	//First Modal
	$(document).on("click", ".modal-close-icon", function (e) {
		e.preventDefault();
		if (JSON.parse(localStorage.getItem("modal")) === null) {
			localStorage.setItem("modal", JSON.stringify("modal"));
		}

		$(".overlay-first-modal").css({
			"opacity": "0",
			"visibility": "hidden",
			"z-index": "-10"
		})
		$(this).parent().css({
			"opacity": "0",
			"visibility": "hidden",
			"z-index": "-10"
		})
	})
	//Header
	// Search div open-close
	$(".open-search-div").click(function () {
		$("#search").slideDown("slow");
	});
	$(".close-inp").click(function () {
		$("#search").slideUp("slow");
	});
	// Cart click overlay
	$(".shopping-cart-header").click(function () {
		$(".overlay-cart").css({
			opacity: "1",
			visibility: "visible",
		});
		$(".header-cart").css({
			transform: "translateX(0%)",
		});
	});
	$(".overlay-cart").click(function () {
		$(".overlay-cart").css({
			opacity: "0",
			visibility: "hidden",
		});
		$(".login-basket").css({
			"opacity": "0",
			"visibility": "hidden"
		})
		$(".header-cart").css({
			transform: "translateX(100%) translatex(30px)",
		});
		$("#modal-prod").css({
			opacity: "0",
			visibility: "hidden",
		});
		$(".phone-side-menu").css({
			opacity: "0",
			visibility: "hidden",
			transform: "translateX(-200px)",
		});
	});
	$(".cart-close-icon").click(function () {
		$(".overlay-cart").css({
			opacity: "0",
			visibility: "hidden",
		});
		$(".header-cart").css({
			transform: "translateX(100%) translatex(30px)",
		});
	});
$(".overlay-cart").click(function(){
	$(".overlay-cart").css({
		"opacity" : "0",
		"visibility" : "hidden"
	})
	$(".header-cart").css({
		"transform": "translateX(100%) translatex(30px)"
	})
	$("#modal-prod").css({
		"opacity" : "0",
		"visibility" : "hidden"
	})
})
$(".cart-close-icon").click(function(){
	$(".overlay-cart").css({
		"opacity" : "0",
		"visibility" : "hidden"
	})
	$(".header-cart").css({
		"transform": "translateX(100%) translatex(30px)"
	})
})

	//Arrival
//Open product Modal
 $(".open-modal").parent().click(function(e){
	 e.preventDefault()
	 $("#modal-prod").css({
		 "opacity" : "1",
		 "visibility" : "visible"
	 })
	 $(".overlay-cart").css({
		"opacity" : "1",
		"visibility" : "visible"
	 })
	 let url = $(this).attr("href");
	 fetch(url).then(res => {
		 return res.text();
	 }).then(data => {
		 $(".ProdModal").html(data);
     })
 })
	// SHOP---->
 // Grid change
	$(".equal").click(function(){
		//self change
		$(this).addClass("active-grid");
		$(".nonequal").removeClass("active-grid");
		// product list change
		$(this).parent().parent().next().find(".product-card").removeClass("product-card-row");

	})
	$(".nonequal").click(function(){
		//self change
		$(this).addClass("active-grid");
		$(".equal").removeClass("active-grid");
		// product list change
		$(this).parent().parent().next().find(".product-card").addClass("product-card-row");
	})
 // Dropdown sidebar menu
	$(".fa-plus").click(function(e){
		e.preventDefault();
		$(this).parent().parent().siblings().find(".sub-list").slideUp();
		//$(".fa-minus").css({
		//	"opacity" : "0",
		//	"visibility" : "hidden"
		//})
		$(".fa-plus").css({
			"opacity" : "1",
			"visibility" : "visible"
		})
		$(this).parent().next(".sub-list").slideDown();

		$(this).css({
			"opacity": "0 ",
			"visibility": "hidden"
		});
		$(this).prev().css({
			"opacity": "1 !important",
			"visibility": "visible !important"
		});
	})
	$(".fa-minus").click(function(e){
		e.preventDefault();
		$(this).parent().parent().siblings().find(".sub-list").slideUp();
		$(this).parent().next(".sub-list").slideUp();
		//$(this).css({
		//	"opacity": "0 ",
		//	"visibility": "hidden "
		//});
		$(this).next().css({
			"opacity" : "1",
			"visibility" : "visible"
		});
	})
	$('ul.tabs li').click(function(){
		var tab_id = $(this).attr('data-tab');
	
		$('ul.tabs li').removeClass('current');
		$('.tab-content').removeClass('current');
	
		$(this).addClass('current');
		$("#"+tab_id).addClass('current');
	})


	// BASKET---->
//Check out
	$(".estimates").click(function(){
		$("#shipping").slideToggle();
	})
	$(".addNote").click(function(){
		$(this).css({"display" : "none"});
		$("#addNoteInput").css({"display" : "block"})
		$(".addNoteLabel").css({"display" : "block"})
	})

	// Window
// To top function
document.querySelector(".topBtn").addEventListener("click",function(){
  window.scrollTo({
    top: 0,
    behavior: 'smooth'
  });
})
	// Parallax background
	function backImgParallax() {
		let offSetY = window.pageYOffset;
		$("#maker").css({
			"background-position-y": `${-(offSetY - 750) * 0.2 + "px"}`
		})
		$("#offer").css({
			"background-position-y": `${-(offSetY - 750) * 0.2 + "px"}`
		})
	}
	backImgParallax();
	$(window).scroll(function () {
		backImgParallax()
    })
	//Profile page

	$(".myaccount-tab-menu .navs").click(function (e) {
		e.preventDefault();
		let name = $(this).attr("data-toggle");
		$(this).parent().find("a").removeClass("active");
		$(this).addClass("active");
		$(".tab-content div").css({
			"display": "none",
			"opacity": "0"
		})
		$(`#${name}`).css({
			"display": "block",
			"opacity": "1"
		})
		$(`#${name} .myaccount-content`).css({
			"display": "block",
			"opacity": "1"
		})
		$(`#${name} .myaccount-table`).css({
			"display": "block",
			"opacity": "1"
		})
		$(`#${name}`).addClass("show active")
    })
})		

// Sticky header
window.onscroll = function () {
	var phoneHeader = document.querySelector(".sticky-header");
	if(window.scrollY >= 240){
		phoneHeader.style.transform = "translateY(0px)";
		phoneHeader.style.transition = "transition: all .5s";
		phoneHeader.style.opacity = "1";
		if (window.scrollY > 1000) {
			const counters = document.querySelectorAll('.value');
			const speed = 200;

			counters.forEach(counter => {
				var animate = () => {
					const value = +counter.getAttribute('akhi');
					const data = +counter.innerText;

					const time = value / speed;
					if (data < value) {
						counter.innerText = Math.ceil(data + time);
						setTimeout(animate, 300);
					} else {
						counter.innerText = value;
					}
				}
				setTimeout(animate, 200);
			});
		}
		}
		else{
		phoneHeader.style.transition = "transition: all .5s";
		phoneHeader.style.transform = "translateY(-80px)";
		phoneHeader.style.opacity = "0";
	
		}
		ScrollToTop();
	}
// Scroll to top button visibility
function ScrollToTop(){
  let scBtn= document.querySelector(".toTopBtn");
  if(window.scrollY > 350){
    scBtn.style.opacity = "1"
    scBtn.style.visibility = "visible"
  }
  else{
    scBtn.style.opacity = "0"
    scBtn.style.visibility = "hidden"
  }
}
// Intro slider
var swiperIntro = new Swiper(".mySwiperIntro", {
	loop : true,
	navigation: {
		nextEl: ".swiper-button-next",
		prevEl: ".swiper-button-prev",
	},
});
	
// Swipe slider
var swipert1 = new Swiper(".mySwiperTab1", {
	slidesPerView: 4,
	grid: {
		rows: 2,
	},
	navigation: {
		nextEl: ".swiper-button-next-t1",
		prevEl: ".swiper-button-prev-t1",
	},
	breakpoints: {
		1020: {
			slidesPerView: 4,
			spaceBetween: 0
		},
		0: {
			slidesPerView: 2,
			spaceBetween: 0
		}
	}
});
var swipert2 = new Swiper(".mySwiperTab2", {
	slidesPerView: 4,
	grid: {
		rows: 2,
	},
	navigation: {
		nextEl: ".swiper-button-next-t2",
		prevEl: ".swiper-button-prev-t2",
	},
	breakpoints: {
		1020: {
			slidesPerView: 4,
			spaceBetween: 0
		},
		0: {
			slidesPerView: 2,
			spaceBetween: 0
		}
	}
});
var swipert3 = new Swiper(".mySwiperTab3", {
	slidesPerView: 4,
	grid: {
		rows: 2,
	},
	navigation: {
		nextEl: ".swiper-button-next-t3",
		prevEl: ".swiper-button-prev-t3",
	},
	breakpoints: {
		1020: {
			slidesPerView: 4,
			spaceBetween: 0
		},
		0: {
			slidesPerView: 2,
			spaceBetween: 0
		}
	}
});

var swiper2 = new Swiper(".mySwiper2", {
	slidesPerView: 4,
	spaceBetween: 30,
	pagination: {
	  el: ".swiper-pagination",
	  clickable: true,
	},
	breakpoints: {
		1020: {
			slidesPerView: 4,
			spaceBetween: 0
		},
		570: {
			slidesPerView: 2,
			spaceBetween: 0
		},
		0: {
			slidesPerView: 1,
			spaceBetween: 0
		}
	}
	});
// Shop left bottom slider
var swiper3 = new Swiper(".mySwiper3", {
	navigation: {
		nextEl: ".swiper-button-next",
		prevEl: ".swiper-button-prev",
	},
});
var swiperModal = new Swiper(".mySwiperModal", {
  navigation: {
	nextEl: ".swiper-button-next-modal",
	prevEl: ".swiper-button-prev-modal",
  },
});