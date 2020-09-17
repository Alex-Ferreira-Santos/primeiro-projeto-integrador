$("#inserir").on("click",function() {
    alert(`${$("#nome").val()} inserido com sucesso`)
})
$("#img").change(() =>{
    var imagem = $("#img").val().split('\\').pop()
    $("#imag").attr('src', `../imagens/${imagem}`)
    console.log(imagem)
    $(".invisible").attr('class',"visible")
})