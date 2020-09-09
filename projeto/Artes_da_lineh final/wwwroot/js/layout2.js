var number = 0
var number1 = 0
function viraSeta(categoria,opcoes){
    $(categoria).on("click",function(){  
        if(number%2==0){
            $(this).attr("class","ativado setaBaixo")
            $(opcoes).css({display:"block"})
            number++
        }else{
            $(this).attr("class","setaBaixo")
            $(opcoes).css({display:"none"})
            number++
        }
    })
}
function trocaImagem(li,opcao,src,src2){
    $(li).on("mouseover",function(){
        $(opcao).attr("src",src)
    })
    $(li).on("mouseout",function(){
        $(opcao).attr("src",src2)
    })
}
function showMenu(){
    $("#menu").on("click",function(){
        if(number1%2==0){
            $("section").attr("class","show")
            number1++
        }else{
            $("section").removeAttr("class")
            number1++
        }
    })
}

viraSeta("#desenho",".desenhos")
viraSeta("#usuario",".usuarios")
viraSeta("#produto",".produtos")
viraSeta("#encomenda",".listagem")
trocaImagem(".insert",".inserir","/imagens/plusc.png","/imagens/plusb.png")
trocaImagem(".edit",".editar","/imagens/pencilc.png","/imagens/pencilb.png")
trocaImagem(".delete",".excluir","/imagens/binc.png","/imagens/binb.png")
trocaImagem(".list",".lista","/imagens/documentoc.png","/imagens/documento.png")
showMenu()