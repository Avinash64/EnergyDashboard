<script setup>
import Chart from 'chart.js/auto';
import { onMounted, ref } from 'vue';

const data = ref([])

onMounted(() => {
  const options = {
    method: 'GET',
    headers: {}
  };
  fetch('http://energydashboardapi.azurewebsites.net/api/stats/top/10', options)
    .then(response => response.json())
    .then(response => {
      console.log(response); data.value = response
    }).then(() => {

      
      const ctx = document.getElementById('barChart');
      console.log(ctx)
      
      new Chart(ctx, {
        type: 'bar',
        data: {
          labels: data.value.map((obj) => { return obj.buildingName; }),
          datasets: [{
            label: 'Energy Usage by Building',
            data: data.value.map((obj) => { return obj.energyUsage; }),
            borderWidth: 1,
            backgroundColor: 'rgba(0,0,200,1)'
            
          }]
        },
        options: {
          scales: {
            y: {
              beginAtZero: true
            }
          }
        }
      })
    })
    })
</script>


<template>
  <div>
    <canvas id="barChart"></canvas>
  </div>
</template>


<style></style>