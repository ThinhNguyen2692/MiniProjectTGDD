/* JS Document */

/******************************

[Table of Contents]

1. Vars and Inits
2. Set Header
3. Init Menu
4. Init Thumbnail
5. Init Quantity
6. Init Star Rating
7. Init Favorite
8. Init Tabs



******************************/

jQuery(document).ready(function($)
{
	"use strict";

	/* 

	1. Vars and Inits

	*/

	var header = $('.header');
	var topNav = $('.top_nav')
	var hamburger = $('.hamburger_container');
	var menu = $('.hamburger_menu');
	var menuActive = false;
	var hamburgerClose = $('.hamburger_close');
	var fsOverlay = $('.fs_menu_overlay');

	setHeader();

	$(window).on('resize', function()
	{
		setHeader();
	});

	$(document).on('scroll', function()
	{
		setHeader();
	});

	initMenu();
	initThumbnail();
	initQuantity();
	initStarRating();
	initFavorite();
	initTabs();

	/* 

	2. Set Header

	*/

	function setHeader()
	{
		if(window.innerWidth < 992)
		{
			if($(window).scrollTop() > 100)
			{
				header.css({'top':"0"});
			}
			else
			{
				header.css({'top':"0"});
			}
		}
		else
		{
			if($(window).scrollTop() > 100)
			{
				header.css({'top':"-50px"});
			}
			else
			{
				header.css({'top':"0"});
			}
		}
		if(window.innerWidth > 991 && menuActive)
		{
			closeMenu();
		}
	}

	/* 

	3. Init Menu

	*/

	function initMenu()
	{
		if(hamburger.length)
		{
			hamburger.on('click', function()
			{
				if(!menuActive)
				{
					openMenu();
				}
			});
		}

		if(fsOverlay.length)
		{
			fsOverlay.on('click', function()
			{
				if(menuActive)
				{
					closeMenu();
				}
			});
		}

		if(hamburgerClose.length)
		{
			hamburgerClose.on('click', function()
			{
				if(menuActive)
				{
					closeMenu();
				}
			});
		}

		if($('.menu_item').length)
		{
			var items = document.getElementsByClassName('menu_item');
			var i;

			for(i = 0; i < items.length; i++)
			{
				if(items[i].classList.contains("has-children"))
				{
					items[i].onclick = function()
					{
						this.classList.toggle("active");
						var panel = this.children[1];
					    if(panel.style.maxHeight)
					    {
					    	panel.style.maxHeight = null;
					    }
					    else
					    {
					    	panel.style.maxHeight = panel.scrollHeight + "px";
					    }
					}
				}	
			}
		}
	}

	function openMenu()
	{
		menu.addClass('active');
		// menu.css('right', "0");
		fsOverlay.css('pointer-events', "auto");
		menuActive = true;
	}

	function closeMenu()
	{
		menu.removeClass('active');
		fsOverlay.css('pointer-events', "none");
		menuActive = false;
	}

	/* 

	4. Init Thumbnail

	*/

	function initThumbnail()
	{
		$(document).ready(function () {
			var bigimage = $("#big");
			var thumbs = $("#thumbs");
			//var totalslides = 10;
			var syncedSecondary = true;

			bigimage
				.owlCarousel({
					items: 1,
					slideSpeed: 2000,
					nav: true,
					autoplay: true,
					dots: false,
					loop: true,
					responsiveRefreshRate: 200,
					navText: [
						'<i class="fa fa-arrow-left" aria-hidden="true"></i>',
						'<i class="fa fa-arrow-right" aria-hidden="true"></i>'
					]
				})
				.on("changed.owl.carousel", syncPosition);

			thumbs
				.on("initialized.owl.carousel", function () {
					thumbs
						.find(".owl-item")
						.eq(0)
						.addClass("current");
				})
				.owlCarousel({
					items: 4,
					dots: true,
					nav: true,
					navText: [
						'<i class="fa fa-arrow-left" aria-hidden="true"></i>',
						'<i class="fa fa-arrow-right" aria-hidden="true"></i>'
					],
					smartSpeed: 200,
					slideSpeed: 500,
					slideBy: 4,
					responsiveRefreshRate: 100
				})
				.on("changed.owl.carousel", syncPosition2);

			function syncPosition(el) {
				//if loop is set to false, then you have to uncomment the next line
				//var current = el.item.index;

				//to disable loop, comment this block
				var count = el.item.count - 1;
				var current = Math.round(el.item.index - el.item.count / 2 - 0.5);

				if (current < 0) {
					current = count;
				}
				if (current > count) {
					current = 0;
				}
				//to this
				thumbs
					.find(".owl-item")
					.removeClass("current")
					.eq(current)
					.addClass("current");
				var onscreen = thumbs.find(".owl-item.active").length - 1;
				var start = thumbs
					.find(".owl-item.active")
					.first()
					.index();
				var end = thumbs
					.find(".owl-item.active")
					.last()
					.index();

				if (current > end) {
					thumbs.data("owl.carousel").to(current, 100, true);
				}
				if (current < start) {
					thumbs.data("owl.carousel").to(current - onscreen, 100, true);
				}
			}

			function syncPosition2(el) {
				if (syncedSecondary) {
					var number = el.item.index;
					bigimage.data("owl.carousel").to(number, 100, true);
				}
			}

			thumbs.on("click", ".owl-item", function (e) {
				e.preventDefault();
				var number = $(this).index();
				bigimage.data("owl.carousel").to(number, 300, true);
			});
		});

	}

	/* 

	5. Init Quantity

	*/

	function initQuantity()
	{
		if($('.plus').length && $('.minus').length)
		{
			var plus = $('.plus');
			var minus = $('.minus');
			var value = $('#quantity_value');

			plus.on('click', function()
			{
				var x = parseInt(value.text());
				value.text(x + 1);
			});

			minus.on('click', function()
			{
				var x = parseInt(value.text());
				if(x > 1)
				{
					value.text(x - 1);
				}
			});
		}
	}

	/* 

	6. Init Star Rating

	*/

	function initStarRating()
	{
		if($('.user_star_rating li').length)
		{
			var stars = $('.user_star_rating li');

			stars.each(function()
			{
				var star = $(this);

				star.on('click', function()
				{
					var i = star.index();

					stars.find('i').each(function()
					{
						$(this).removeClass('fa-star');
						$(this).addClass('fa-star-o');
					});
					for(var x = 0; x <= i; x++)
					{
						$(stars[x]).find('i').removeClass('fa-star-o');
						$(stars[x]).find('i').addClass('fa-star');
					};
				});
			});
		}
	}

	/* 

	7. Init Favorite

	*/

	function initFavorite()
	{
		if($('.product_favorite').length)
		{
			var fav = $('.product_favorite');

			fav.on('click', function()
			{
				fav.toggleClass('active');
			});
		}
	}

	/* 

	8. Init Tabs

	*/

	function initTabs()
	{
		if($('.tabs').length)
		{
			var tabs = $('.tabs li');
			var tabContainers = $('.tab_container');

			tabs.each(function()
			{
				var tab = $(this);
				var tab_id = tab.data('active-tab');

				tab.on('click', function()
				{
					if(!tab.hasClass('active'))
					{
						tabs.removeClass('active');
						tabContainers.removeClass('active');
						tab.addClass('active');
						$('#' + tab_id).addClass('active');
					}
				});
			});
		}
	}
});