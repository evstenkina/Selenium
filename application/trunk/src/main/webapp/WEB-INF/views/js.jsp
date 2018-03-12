<%@ taglib uri="http://java.sun.com/jsp/jstl/core" prefix="c"%>
<%@ page session="false"%>
<html>
<head>
    <title>Selenium test application</title>
    <script type="text/javascript" src="http://code.jquery.com/jquery-1.8.2.min.js" ></script>
    <style type="text/css">
.flash {
    border:1px solid red
}
    </style>
    <script type="text/javascript">
    document.onready = function (){
        regenerate();
    };
    function process(){
        var realleft = Math.round($(".flash").css("left").replace("px",""));
        var realtop = Math.round($(".flash").css("top").replace("px", ""));
        if ($("#top").val() == realtop && $("#left").val() == realleft ) {
            alert("Whoo Hoooo! Correct!");
        } else {
            alert("Wrong anser. Correct is: left=" + realleft + ", top=" + realtop);
            regenerate();
        }
    }

    function regenerate(){
        $(".flash").css({ "position": "absolute", "top": getrand(300) + 200 + "px", "left": getrand(700) + "px" });
    }

    function getrand(range){
        return Math.random() * range;
    }
    </script>
</head>

<body>
<p>Take the coordinates (top and left) of the red div, type them into the input and press verify button. Check the alert message</p>
Top:<input id="top" type="text" /> <br/>
Left:<input id="left" type="text" /> <br/>
<button onclick="process()" id="process">Process</button>
<hr/>
<div class="flash"> Find me !</div>
</body>
</html>