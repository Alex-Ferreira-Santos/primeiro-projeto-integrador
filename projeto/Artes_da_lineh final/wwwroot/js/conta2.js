$(function(){
    $('#avatar').change(function(){
        const file = document.querySelector("#avatar").value
        if(file!=null){
            $('#imagem').attr('src', file)
        }
    })
})
$("#concluir").on("click",function(){
    alert(`Usuário ${$("#nome").val()} criado com sucesso`)
})