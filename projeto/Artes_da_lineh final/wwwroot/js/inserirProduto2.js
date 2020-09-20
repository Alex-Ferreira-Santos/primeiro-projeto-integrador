$("#inserir").on("click",function() {
    alert(`${$("#nome").val()} inserido com sucesso`)
    
})
function Mudaimagem(atributo){
    $(atributo).change(() =>{
        var imagem = $(atributo).val().split('\\').pop()
        $("#imag").attr('src', `../imagens/${imagem}`)
        $(".invisible").attr('class',"visible")
    })
}
var a = 2
$("#add").on("click",()=>{
    if(a<=5){
        $(`#label${a}`).removeClass("invisibleImg")
        $(`#imagem${a}`).removeClass("invisibleImg")
        a++
    }
})

Mudaimagem("#img")
Mudaimagem(".imagem")
Mudaimagem("#imagem2")
Mudaimagem("#imagem3")
Mudaimagem("#imagem4")
Mudaimagem("#imagem5")
