//jQuery(function () {

    
//})

//jQuery(document).ready(function ($) {
//    $.post("/handler/loadImgHandler.ashx", {
//        p: "xd",
//        id: '147242'
//    },
//    function (data) {
//        $("#jqlist").html(data)
//    },
//    "html");
//    $.post("/handler/getSXHandler.ashx", {
//        p: "xd",
//        id: '147242'
//    },
//    function (data) {
//        $("#attributes").html(data)
//    },
//    "html");
//    $(".scrollLoading").scrollLoading();
//    var color = new Select("color", {
//        Radio: true,
//        OnClick: function (selected) {
//            $("#colors").val(selected.join(","))
//        }
//    });
//    var size = new Select("size", {
//        OnClick: function (selected) {
//            $("#sizes").val(selected.join(","))
//        }
//    });
//    $(".jqzoom").jqueryzoom({
//        xzoom: 380,
//        yzoom: 410
//    })
//});

$(document).ready(function () {
    //alert("文章管理");
    $(".nav-sidebar a").click(function () {
        
    //$("#manage-sidebar a").click(function () {
        var action = "";
        var type = $(this).text();
        //alert(type);
        if(type == "文章管理"){
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
        getMain(action);
    });
});

function getMain(action) {
    //alert("getMain");
    $.get("/Manage/"+action+"",
        function (data) {
            //alert("data:" + data);
            $(".main").html(data)
        },
        "html");

}