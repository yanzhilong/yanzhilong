$(document).ready(function () {

    /* 文章及教程列表页内容 */
    $(".list_content").each(function () {
        $clamp(this, { clamp: 3, useNativeClamp: false });
    });

    /* 首页教程内容 */
    $(".marketing .col-lg-4 p").each(function () {
        $clamp(this, { clamp: 3, useNativeClamp: false });
    });
    
    /* 首页教程标题 */
    
    $(".main_tutorials .blog-post-title").each(function () {
        $clamp(this, { clamp: 1, useNativeClamp: false });
    });
});