$(function(){
    $('#avatar').change(function(){
        const file = $(this)[0].files[0]
        const fileReader = new FileReader()
        fileReader.onloadend = function(){
            $('#imagem').attr('src', fileReader.result)
        }
        fileReader.readAsDataURL(file)
    })
})
$("#concluir").on("click",function(){
    alert(`Usuário ${$("#nome").val()} criado com sucesso`)
})