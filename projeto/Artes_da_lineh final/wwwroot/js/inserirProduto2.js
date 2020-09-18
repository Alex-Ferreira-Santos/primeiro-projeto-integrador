const images = []
$("#inserir").on("click",function() {
    alert(`${$("#nome").val()} inserido com sucesso`)
    images.push($("#img").val().split('\\').pop())
    $.post("/Produtos/Product",{images})
        .done(data=>{
            $("main").html(data)
        })
        .fail(()=>{
            alert("Falha na requisição")
        })
})
$("#img").change(() =>{
    var imagem = $("#img").val().split('\\').pop()
    $("#imag").attr('src', `../imagens/${imagem}`)
    $(".invisible").attr('class',"visible")
    $("#confirmaImagem").attr('class',"invisible")
    $("#cancelaImagem").attr('class',"invisible")
})

$("#imagem").change(() =>{
    var imagem = $("#imagem").val().split('\\').pop()
    $("#imag").attr('src', `../imagens/${imagem}`)
    $(".invisible").attr('class',"visible")
    $("#confirmaImagem").attr('class',"visible btn btn-success")
    $("#cancelaImagem").attr('class',"visible btn btn-danger")
})

$("#confirmaImagem").on("click",()=>{
    alert($("#imagem").val().split('\\').pop() + " adionado a lista")
    images.push($("#imagem").val().split('\\').pop())
})
