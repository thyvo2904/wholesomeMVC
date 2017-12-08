$(document).ready(function () {
	$("#banner").vegas({
		slides: [
			{ src: "/Content/Images/Backgrounds/01.png" },
			{ src: "/Content/Images/Backgrounds/02.png" },
			{ src: "/Content/Images/Backgrounds/03.png" },
			{ src: "/Content/Images/Backgrounds/04.png" },
			{ src: "/Content/Images/Backgrounds/05.png" },
			{ src: "/Content/Images/Backgrounds/06.png" },
			{ src: "/Content/Images/Backgrounds/07.png" },
			{ src: "/Content/Images/Backgrounds/08.png" },
			{ src: "/Content/Images/Backgrounds/09.png" },
			{ src: "/Content/Images/Backgrounds/10.png" },
			{ src: "/Content/Images/Backgrounds/11.png" },
			{ src: "/Content/Images/Backgrounds/12.png" },
			{ src: "/Content/Images/Backgrounds/13.png" },
			{ src: "/Content/Images/Backgrounds/14.png" },
			{ src: "/Content/Images/Backgrounds/15.png" },
			{ src: "/Content/Images/Backgrounds/16.png" },
			{ src: "/Content/Images/Backgrounds/17.png" },
			{ src: "/Content/Images/Backgrounds/18.png" },
		],
		shuffle: true,
		delay: 15000,
		color: "#FAFAFA",
		animation: "random",
		transition: [ "fade", "blur" ],
	});
});