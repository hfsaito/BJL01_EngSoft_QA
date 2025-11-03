# Report 03 - Dobro de dano ao cair na cabeça do inimigo
- ID: \[Prog\] E003
- Prioridade: Média
  - Comportamento inesperado na jogabilidade

## Descrição
A segunda instrução que o jogo passa é: _If you fall on enemy's head, it deals double damage_

Porem ao cair na cabeça do inimigo o jogador não sofre dano algum

## Reprodução
Pular na cabeça do inimigo próximo a segunda instrução

## Resultado Encrontrado
Jogador não sofre dano

## Resultado Esperado
Sofrer o dobro de dano

## Root cause
No arquivo `Assets/MyAssets/Scripts/Inimigo.cs` podemos ver o método `OnTriggerEnter2D` que aplica o dano ao jogador quando o inimigo colide com ele
```csharp
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            Vector3 entryDir = collision.transform.position - transform.position;
            entryDir.Normalize();
            if (entryDir.y < 0.5f)
            {
                collision.transform.GetComponent<Player>().MudarVida(-dano);
            }
        }
    }
```

Já conseguimos ver que o dano duplo não está implementado

Para entender melhor o vetor `entryDir` fiz o seguinte desenho

![vetor entryDir](https://github.com/hfsaito/BJL01_EngSoft_QA/blob/main/reports/03/entryDir.png?raw=true)

Somando essas duas pistas entende-se que o dano só é aplicado caso a direção de contado entre o jogador e o inimigo tenha o componente vertical menor que .5

Sendo assim, apenas quando o jogador encosta no inimigo por baixo ou pelos lados que ele sofrerá dano

![direções que se aplicaria dano](https://github.com/hfsaito/BJL01_EngSoft_QA/blob/main/reports/03/dir-dano.png?raw=true)

## Correção
Faz mais sentido o jogador não sofrer dano se encostar por baixo, invertendo a situação atual. De `entryDir.y < 0.5f` para `entryDir.y > -0.5f`

E adicionar o dano duplo em um ponto maior, minha sugestão é `entryDir.y > (Mathf.Sqrt(3) / 2)`, que é quando o angulo de contato é maior que 60 graus

![direções que se aplicaria dano corrigido](https://github.com/hfsaito/BJL01_EngSoft_QA/blob/main/reports/03/fix.png?raw=true)

https://github.com/hfsaito/BJL01_EngSoft_QA/commit/edd3be0500c86d8de5312627d93bcc350e98e787
