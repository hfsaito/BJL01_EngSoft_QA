# Report 02 - Pular com W
## Descrição
Ao apertar `W` o personagem não pula apesar de aparecer a instrução para o jogador: _Press "W" or Space to jump_

## Reprodução
Apertar `W`

## Resultado Encrontrado
Não acontece nada

## Resultado Esperado
Personagem pular

## Root cause
Verificando o script `Assets/MyAssets/Scripts/Player.cs`, no método `HandleJumping`. A tecla sendo usada como alternativa para o pulo é o `S`

## Correção
Trocar para usar o `W` na linha `Assets/MyAssets/Scripts/Player.cs:63`

De

```csharp
    private void HandleJumping()
    {
        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.Space) && jumpAmount > 0)
        {
```

Para
```csharp
    private void HandleJumping()
    {
        if (
            (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Space))
            && jumpAmount > 0
        )
        {
```
_Reformatado para ficar mais fácil de ler_

https://github.com/hfsaito/BJL01_EngSoft_QA/commit/7c8fc76355bb7623393b48a2a7d5c0c69e582808
