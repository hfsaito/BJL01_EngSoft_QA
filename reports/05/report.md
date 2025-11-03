# Report 05 - Item vida permanece ao ser coletado
- ID: \[Prog\] E005
- Prioridade: Média

## Descrição
Ao pegar o item vida, o item permanece no jogo possibilitando o jogar usar infinitas vezes.

## Reprodução
Passar pelo item vida.

## Resultado Encrontrado
Recupra vida e o item permance no jogo.

## Resultado Esperado
Recupra vida e o item ser removido no jogo.

## Root cause
Ao verificar o script `Assets/MyAssets/Scripts/Vida.cs` é possível ver que o método `OnTriggerEnter2D` apenas chama o método `MudarVida` do jogador e nada mais.

## Correção
Chamar o método `Destroy` dentro do método `OnTriggerEnter2D` passando `gameObject` como argumento, já que está no contexto do item vida `gameObject` irá se referir ao próprio objeto em que o script está presente.
