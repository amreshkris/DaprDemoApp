function selectanswer() {  
    $(document).ready(function () {
        $('.list-group-item').click(function () { 
            $(this).siblings().removeClass("active");
            $(this).siblings().removeClass("list-group-item-success");
            $(this).addClass("active");
        });
    }); 
}

function highlightanswer() {
    $(document).ready(function () {        
        $('.list-group-item').removeClass("active");
        $('#answer_1,#answer_2').addClass("list-group-item-success");        
    });
}

function removehighlight() {
    $(document).ready(function () {
        $('#answer_1,#answer_2').removeClass("list-group-item-success");        
    });
}