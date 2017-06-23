/* 设置上下的位移 */
$('.sidebar-nav').affix({
    offset: {

        //防止在有顶部页面及其它内容的时候一开始就直接定位到上边距
        top: $('.sidebar-nav').offset().top - 29,

        //防止到达底部了，导航条还跟着下来
        bottom: ($('footer').outerHeight(true) +
            $('.application').outerHeight(true)) + 40
    }
});

jQuery(function () {

    function makeSildebar(para) {
        var lis = "";
        para.children("h1,h2,h3,h4,h5,h6").each(function (index) {

            var parli = "";
            parli = "<li>";

            //				alert(index)
            var idvalue = $(this).attr("id")
            //				alert(idvalue)
            //				var title = $(this).children("h2").length
            var title = $(this).text()
            //				alert(title)
            parli += "<a href=\"#" + idvalue + "\">" + title + "</a>"

            //				alert(idvalue)
            //判断是否还有子元素
            var childrens = $(this).children("h1,h2,h3,h4,h5,h6");
            var chilcount = childrens.length;
            //				alert(chilcount)
            // 有子元素，添加下级ul
            var ul = "";
            if (chilcount > 0) {

                ul = "<ul class=\"nav\">"

                var childlis = makeSildebar($(this));
                ul += childlis;

                ul += "</ul>"
            }
            parli += ul;
            parli += "</li>"
            lis += parli;
        });
        return lis;
    }

    $("ul.sidebar-ul").append(makeSildebar($("div.col-md-9:first")));

    //$("div.col-md-9:first").children("h1,h2,h3,h4,h5,h6").each(function (index) {

    //    var parli = "";
    //    parli = "<li>";
    //    var idvalue = $(this).attr("id")
    //    var title = $(this).find("h2:first").text()
    //    parli += "<a href=\"#" + idvalue + "\">" + title + "</a>"

    //    //				alert(idvalue)
    //    //判断是否还有子元素
    //    var childrens = $(this).children("section")
    //    var chilcount = childrens.length
    //    // 有子元素，添加下级ul
    //    var ul = "";
    //    if (chilcount > 0) {

    //        ul = "<ul class=\"nav\">"

    //        var childsection = $(this).children("section");
    //        var li = "";
    //        childsection.each(function (dex) {

    //            li = "<li>";

    //            var idvalue = $(this).attr("id")
    //            var title = $(this).children("h2").length
    //            var title = $(this).find("h3:first").text()
    //            li += "<a href=\"#" + idvalue + "\">" + title + "</a>"

    //            li += "</li>"
    //            ul += li

    //        })
    //        ul += "</ul>"
    //    }
    //    parli += ul;
    //    parli += "</li>"
    //    $("ul.sidebar-ul").append(parli);

    //})
})

! function (a) {
    a(function () {
        c = a(document.body);
        c.scrollspy({
            target: ".sidebar-nav"
        })
    })
}(jQuery);