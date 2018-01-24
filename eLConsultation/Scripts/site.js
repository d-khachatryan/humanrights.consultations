//Grid height
var winHeight = $(window).height();
var headerHeight = $("header.navbar").height();
var footerHeight = $("footer.app-footer").height();
$(".container-fluid").height(winHeight - headerHeight - footerHeight - 23);
$(".k-grid:not(.card-body .k-grid)").height($(".container-fluid").height() - 45);
$("#catalog .k-grid").height($(".container-fluid").height());




//For Grid Commands Icons
function showCommandIcons() {
    $(".Update_Icon").html("").append("<span class=\"icons icon-pencil\"></span>");
    $(".Delete_Icon").html("").append("<span class=\"icons icon-trash\"></span>");
    $(".Details_Icon").html("").append("<span class=\"icons icon-list\"></span>");
    $(".Plus_Icon").html("").append("<span class=\"fa fa-plus\"></span>");
    $(".Remove_Icon").html("").append("<span class=\"icons icon-close\"></span>");
}


function dispatcherExtraStylingToGrid() {
    //$(".k-grid  table tr").hover(function () {
    $(".k-grid > div.k-grid-content > table > tbody > tr.k-master-row").hover(function () {
        $(this).addClass('trHover');
    }, function () {
        $(this).removeClass('trHover');
    });
}


//For PopUp Grid Commands Icons
function correctPopUpGrid(e) {
    setTimeout(function () {
        $(".k-grid-edit").html("<span class=\"icons icon-pencil\"></span>")
        $(".k-grid-delete").html("<span class=\"icons icon-trash\"></span>")
    });
}

//Error handler Grid
function error_handler(e, status) {
    alert("Սերվերում առկա է խնդիր։ Տվյալները չեն կարող ցուցադրվել");
}

//For Right Slide
var next_move = "closed";
$(".right-slidePanel .slidePanel-btn").html("<i class=\"icons icon-magnifier\"></i>");
$(".right-slidePanel .slidePanel-btn, .right-slidePanel #btnSearch")
    .click(function () {
        console.log(next_move);
        var css = {};
        if (next_move == "closed") {
            css = {
                right: '0'
            };
            $(".right-slidePanel .slidePanel-btn").html("<i class=\"icons icon-arrow-right\"></i>");
            next_move = "shrink";
        } else {
            css = {
                right: '-230px'
            };
            console.log('hi');
            next_move = "closed";
            $(".right-slidePanel .slidePanel-btn").html("<i class=\"icons icon-magnifier\"></i>");
        }
        $(this).closest(".right-slidePanel").animate(css, 200);
    });
