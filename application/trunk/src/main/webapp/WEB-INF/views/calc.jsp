<%@ taglib uri="http://java.sun.com/jsp/jstl/core" prefix="c"%>
<%@ page session="false"%>
<html>
<head>
    <title>Selenium test application</title>
    <script type="text/javascript" src="http://code.jquery.com/jquery-1.8.2.min.js" ></script>

    <script type="text/javascript">
    document.onready = function (){
        $("#clear").hide();
    };
    function calc(){
      $("#calc").hide();
      $("#clear").show();
        $.get('/calc/sum?x=' + $("#x").val() + "&y=" + $("#y").val(),
            function (data) {
                $("#r").append('<div id="result">Result is: ' + data.result + '</div>');
            }
        );
    }
    function fclear(){
     $("#x").val("");
     $("#y").val("");
     $("#result").remove();
     $("#calc").show();
     $("#clear").hide();
    }
    </script>
</head>

<body>
<p>Simple calculator. Enter x and y, press the button, wait for result and verify it</p>
X:<input id="x" type="text" /> <br/>
Y:<input id="y" type="text" />
<hr/>
<div id="r"> </div>
<button onclick="calc()"  id="calc">Sum</button>
<button onclick="fclear()"  value="Sum" id="clear">Clear</button>
<hr/>
<a href="/">go back</a>

</body>
</html>