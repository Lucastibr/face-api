const express = require('express');
const path = require('path');
const fs = require('fs');
const app = express();
const PORT = 3000;

app.use(express.static(path.join(__dirname, 'public')));
app.use(express.json({ limit: '50mb' })); // Para aceitar imagens grandes em base64

// Rota para receber a imagem base64
app.post('/upload', (req, res) => {
  const { image } = req.body;
  if (!image) {
    return res.status(400).send('Nenhuma imagem foi enviada.');
  }

  // Remover o prefixo "data:image/jpeg;base64,"
  const base64Data = image.replace(/^data:image\/jpeg;base64,/, '');

  // Salvar a imagem em um arquivo
  const filePath = path.join(__dirname, 'uploads', `image-${Date.now()}.jpeg`);
  fs.writeFile(filePath, base64Data, 'base64', (err) => {
    if (err) {
      console.error('Erro ao salvar a imagem:', err);
      return res.status(500).send('Erro ao salvar a imagem.');
    }

    res.json({ message: 'Imagem salva com sucesso!', path: filePath });
  });
});

// Iniciar o servidor
app.listen(PORT, () => {
  console.log(`Servidor rodando na porta ${PORT}`);
});
