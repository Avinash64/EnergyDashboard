<script setup>
import Chart from 'chart.js/auto';
import { onMounted } from 'vue';


onMounted(()=>{

    const ctx = document.getElementById('barChart');
    console.log(ctx)

new Chart(ctx, {
  type: 'bar',
  data: {
      labels: ['2010', '2011', '2012', '2013', '2014', '2015'],
      datasets: [{
      label: 'Energy Usage by Year',
      data: [12, 19, 3, 5, 2, 3],
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
});
})
</script>


<template>
<div>
  <canvas id="barChart"></canvas>
</div>

</template>


<style>

</style>