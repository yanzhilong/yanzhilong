var currentli = null;
$(document).ready(function () {
    //alert("文章管理");
    $(".nav-sidebar a").click(function () {
        
    //$("#manage-sidebar a").click(function () {
        var action = "";
        var type = $(this).text();
        //alert(type);
        if (type == "管理中心") {
            action = "Index";
            //alert("管理中心");
        } else if (type == "文章管理") {
            action = "Article";
            //alert("文章管理");
        }else if(type == "分类管理"){
            action = "Category";
            //alert("分类管理");
        }else if(type == "教程管理"){
            action = "Tutorials";
            //alert("教程管理");
        }else if(type == "产品管理"){
            action = "Product";
            //alert("产品管理");
        }
        //$("p").slideToggle();
        getMain("/Manage/" + action);
        select_li(this);
        //不触发a链接
        return false;
    });
    currentli = $(".nav-sidebar a").first();
    //拉取管理中心
    getMain("/Manage/Manage");
});

function getMain(href_) {
    //alert("getMain");
    $.get(href_,
        function (data) {
            //alert("data:" + data);
            $(".main").html(data)
            operatorPage();
        },
        "html");
}

function operatorPage() {
    $(".pagination a").click(function () {

        getMain($(this).attr("href"));
        //alert($(this).attr("href"))
        return false;
    });
}

function select_li(select_a) {
    lis = $(".nav-sidebar li")
    var text = $(select_a).text();
    if (text == currentli.text()) {
        return;
    }
    currentli = $(select_a);

    lis.each(function () {

        if (currentli.text() == $($(this).children("a").get(0)).text()) {
            $(this).addClass("active");
        } else {
            $(this).removeClass("active");
        }
    });
}