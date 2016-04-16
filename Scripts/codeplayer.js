$(function () {

    var height = $(window).height() - 40;

    $(".codecontainer").css("height", height + "px");
    $(".selector").hover(function (event) {
        return false;
    });
    $(".selector").click(function (event) {

        var $this = $(this);
        if (!$this.hasClass('active')) {
            $this.addClass('active');
        }
        else { $this.removeClass('active'); }
        var id = $(this).attr("name");

        $("#" + id + "Container").toggle();

        var number = $('.codecontainer').filter(function () {
            return $(this).css('display') !== 'none';
        }).length;
        var width = 100 / number;

        $(".codecontainer").css("width", width + "%");
    });


    $("#run").click(function () {

        $('#resultFrame').contents().find('html').html("<style>" + $('#css').val() + "</style>" + $("#html").val());

        document.getElementById('resultFrame').contentWindow.eval($('#js').val());
    });

    $("#save").click(function () {
        var cont = $("#html").val();
        var cont1 = $("#css").val();
        var cont2 = $("#js").val();
        $("#myModal #htmlcode").val(cont);
        $("#myModal #csscode").val(cont1);
        $("#myModal #jscode").val(cont2);
        $("#myModal").modal();
    });

    $("#savethis").click(function () {

        var model = {
            Name: $("#nameforProject").val(),
            Html: $("#html").val(),
            CSS: $("#css").val(),
            JS: $("#js").val()
        };

        $.ajax({
            url: "/Home/SavePost",
            type: "POST",
            data: model,
            success: function (data, textStatus, jqXHR) {
                //data - response from server
                $("#success-record").toggle().delay(3000).queue(function () {
                    $("#success-record").hide();
                    $("#nameforProject").val("");
                    $('#myModal').modal('toggle');
                    $(this).dequeue();
                });
            },
            error: function (jqXHR, textStatus, errorThrown) {

            }
        })
    });
});