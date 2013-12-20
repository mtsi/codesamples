/**
Use the equalHeight function to make a certain group of DIVs an equal height.
Call this in the $(document).ready() function and pass in the name of the class that
you want to equalize. This code will do the rest for you.
**/
function equalHeight(group) {
    tallest = 0;
    group.each(function() {
        thisHeight = $(this).height();
        if(thisHeight > tallest) {
            tallest = thisHeight;
        }
    });
    group.each(function() { $(this).height(tallest); });
}

$(document).ready(function() {
    equalHeight($(".thumbnail"));
});