import express, { json } from 'express';
import axios from 'axios';
import dotenv from 'dotenv';

dotenv.config();
const app = express();
app.use(json());

const PORT = process.env.PORT || 3000;
const ACCESS_TOKEN = process.env.ACCESS_TOKEN;

app.post('/create-preapproval-plan', async (req, res) => {
  const { reason, amount } = req.body
  try {
    const response = await axios.post('https://api.mercadopago.com/preapproval_plan', {
      reason: reason,
      auto_recurring: {
        frequency: 1,
        frequency_type: "months",
        billing_day: 10,
        billing_day_proportional: false,
        transaction_amount: amount,
        currency_id: "BRL"
      },
      payment_methods_allowed: {
        payment_types: [
          {
            id: "credit_card"
          }
        ],
        payment_methods: [
          {
            id: "bolbradesco"
          }
        ]
      },
      back_url: "https://www.yoursite.com"
    },
      {
        headers: {
          Authorization: `Bearer ${ACCESS_TOKEN}`,
          'Content-Type': 'application/json'
        }
      });
    res.status(200).json(response.data);
  } catch (error) {
    res.status(500).json({ error: error.message });
  }
});


app.post('/create-preapproval', async (req, res) => {
  const { preapproval_plan_id, reason, email, card_token_id, amount } = req.body;
  try {
    const response = await axios.post('https://api.mercadopago.com/preapproval', {
      preapproval_plan_id: preapproval_plan_id,
      reason: reason,
      external_reference: "YG-1234",
      payer_email: email,
      card_token_id: card_token_id,
      auto_recurring: {
        frequency: 1,
        frequency_type: "months",
        transaction_amount: amount,
        currency_id: "BRL"
      },
      back_url: "https://www.mercadopago.com.br",
      status: "authorized"
    }, {
      headers: {
        Authorization: `Bearer ${ACCESS_TOKEN}`,
        'Content-Type': 'application/json'
      }
    });
    res.status(200).json(response.data);
  } catch (error) {
    res.status(500).json({ error: error.message });
  }
});

app.listen(PORT, () => {
  console.log(`Servidor rodando na porta http://localhost:${PORT}`);
});
