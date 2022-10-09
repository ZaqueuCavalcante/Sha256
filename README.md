# Sha256

Onde está a segurança do JWT? (E do Bitcoin? E da web?)

Muito utilizado em APIs mundo a fora, mas o que garante a segurança? Pra variar, Matemática!

O único jeito de gerar um token válido é descobrir a chave usada para assinar o JWT.

## O que é?



## SHA256

### Conceitos

- Bit -> 0 ou 1
- Byte -> Sequência de 8 bits (01111001)
- Word -> Sequência de 32 bits (01111001 01101001 01110111 01110011)
- Block -> Sequencia de 512 bits
(
	01111001 01101001 01110111 01110011
	01100101 01100111 01100110 01111001
	01110111 01100101 01110010 01111001
	01100110 01101001 01110110 01110111
	01111001 01100101 01100110 01110110
	01100010 01111001 01110111 01100101
	01110010 01110011 01100110 01110110
	01111001 01110111 01101001 01100101
	01110110 01100110 01101100 01111001
	01100101 01110010 01110111 01100111
	01110110 01111001 01110010 01110011
	01110111 01110110 01100110 01100111
	01100001 01110101 11000011 10100111
	01110011 01100010 01110101 01100111
	01100111 01110011 01110111 01100111
	01100101 01110010 01110010 01100111
)

- Bitwise Operations -> Operações matemáticas (lógica booleana?) feitas em cima de bits
	- AND -> 1&1=1 \ 1&0,0&1,0&0=0
	- OR -> 0|0=0 \ 0|1,1|0,1|1=1
	- NOT -> ~0=1 \ ~1=0
	- XOR -> 0^0,1^1=0 \ 0^1,1^0=1

- As operações a seguir são feitas em cima das words
	- Right Shift -> Divide pro x -> 0100>>0001=1000
	- Circular Right Shift -> Pega o bit mais a direita e joga na esquerda
	- Exclusive Or -> XOR
	- Addition -> Adição simples, limitada a 32 bit no resultado (modulus 2**32)

- Funções -> As operações acima podem ser combinadas para criar funções
	- Rotational Funcitions:
		- sigma0 -> rot, rot, right, xor
		- sigma1 -> rot, rot, right, xor
		- usigma0 -> rot, rot, rot, xor
		- usigma1 -> rot, rot, rot, xor
	- Choice:
		- Usa x bits pra escolher entre y e z bits
		- Se x=1->y \ Se x=0->z
	- Majority:
		- Retorna o bit que mais aparece dos 3 números

- Constantes -> São usadas 64 constantes para 'mixing up' durante o hash
	- Raiz cúbica dos primeiros 64 primos
	- Como os valores são irracionais, eleva a aleatoriedade (back-door)
	- Multiplica os valores por 2**32 e usa o inteiro como constante

- Message -> 






- Processo de converter um input de tamanho qualquer em um output de tamanho fixo:
	- Como pode ser tão rápido para arquivos grandes?
	- Uma palavra ou a wikpédia inteira dão na mesma?
- Uso de algum algoritmo / função matemática (hash function)
- Input + hash function = hash value
- MD2, CRC32, MD5, SHA-1, SHA-256, SHA-512, Tiger, RipeMD128, Adler32
- A função precisa:
	- Hash value must be unique (espalhamento) / inputs diferentes -> outputs diferentes
	- Same input -> same hash
	- Precisa rodar rápido (mas se for muito rápido, pode ser quebrável?)
	- Deve ser impossível obter o input olhando apenas pro output
	- Basta 1 bit ser alterado no input, que o output é totalmente diferente (Avalanche Effect)

- Uses:
	- Blockchain (transaction_id)
	- Git
	- Password storage (salt?)
	- Arquivos em perícia criminal
	- Secure downloads
	- Cryptography, Digital Signatures, Authentication

- https://github.com/in3rsha/sha256-animation


## Referências
- [What is Hashing? Hash Functions Explained Simply](https://youtu.be/2BldESGZKB8)
- [What is Hashing on the Blockchain?](https://youtu.be/IGSB9zoSx70)
- [What is a Cryptographic Hashing Function? (Example + Purpose)](https://youtu.be/gTfNtop9vzM)
- [The unsolved math problem which could be worth a billion dollars](https://youtu.be/8COArd_EREw)
- [SHA: Secure Hashing Algorithm - Computerphile](https://youtu.be/DMtFhACPnTY)
- [SHA-256 Animation](https://github.com/in3rsha/sha256-animation)
- []()
- []()
- []()


https://github.com/in3rsha/sha256-animation
https://en.wikipedia.org/wiki/SHA-2
https://blog.boot.dev/cryptography/how-sha-2-works-step-by-step-sha-256/
https://blog.pagefreezer.com/sha-256-benefits-evidence-authentication
