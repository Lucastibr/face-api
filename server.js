const express = require('express');
const multer = require('multer');
const path = require('path');
const fs = require('fs');

const app = express();
const PORT = 3000;

// Configurar o Express para servir arquivos estáticos da pasta 'public'
// Servir arquivos estáticos da pasta 'public'
app.use(express.static(path.join(__dirname, 'public')));

// Configurar o multer para salvar as imagens enviadas
const storage = multer.diskStorage({
  destination: function (req, file, cb) {
    cb(null, 'uploads/');
  },
  filename: function (req, file, cb) {
    const uniqueSuffix = Date.now() + '-' + Math.round(Math.random() * 1E9);
    cb(null, file.fieldname + '-' + uniqueSuffix + path.extname(file.originalname));
  }
});

const upload = multer({ storage: storage });

// Criar a pasta de uploads se ela não existir
if (!fs.existsSync('./uploads')) {
  fs.mkdirSync('./uploads');
}

// Rota para receber e salvar a imagem
app.post('/upload', upload.single('image'), (req, res) => {
  res.json({ message: 'Imagem salva com sucesso!', filename: req.file.filename });
});

// Iniciar o servidor
app.listen(PORT, () => {
  console.log(`Servidor rodando na porta ${PORT}`);
});
