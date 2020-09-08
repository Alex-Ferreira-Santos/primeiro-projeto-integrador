$("#desenho").on("click",function(){
    var number = 0
    if(number%2==0){
        $(this).attr("class","ativado")
        number++
    }else{
        $(this).removeAttr("class","ativado")
        number++
    }
})