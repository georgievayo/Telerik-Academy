function solve() {
	return function() {
		var template = 
			'<h1>{{title}}</h1>',
			'<ul>',
			'{{#posts}}',
			'<li>',
			'<div class="post">',
			'<p class="author">',
			'{{#if author}}',
			'<a class="user" href="/user/{{author}}">{{author}}</a>',
			'{{else}}',
			'<a class="anonymous">Anonymous</a>',
			'{{/if}}',
			'</p>',
			'<pre class="content">{{{text}}}</pre>',
			'</div>',
			'{{#if comments}}',
			'<ul>',
			'{{#comments}}',
			'{{#unless deleted}}',
			'<li>',
			'<div class="comment">',
			'<p class="author">',
			'{{#if author}}',
			'<a class="user" href="/user/{{author}}">{{author}}</a>',
			'{{else}}',
			'<a class="anonymous">Anonymous</a>',
			'{{/if}}',
			'<pre class="content">{{{text}}}</pre>',
			'</div>',
			'</li>',
			'{{/unless}}',
			'{{/comments}}',
			'</ul>',
			'{{/if}}',
			'</li>',
			'{{/posts}}',
			'</ul>';

		document.getElementById(selector).innerHTML = template;
	}
}

// submit the above

if(typeof module !== 'undefined') {
	module.exports = solve;
}
